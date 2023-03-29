
using AutoMapper;
using Library.BusinessLayer.DTO_s;
using Library.BusinessLayer.Exceptions;
using Library.BusinessLayer.Requests;
using Library.BusinessLayer.Services.Interfaces;
using Library.DataAccess.Models;
using Library.DataAccess.Repositories;
using Library.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;

namespace Library.BusinessLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ILogger<BookService> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository, ILogger<BookService> logger,
            IMapper mapper, IUnitOfWork unitOfWork, IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _genreRepository = genreRepository;
        }

        public async Task<BookDto> AddAsync(BookRequest book, CancellationToken cancellation)
        {
            var bookMapped = _mapper.Map<Book>(book);

            bookMapped.Genres = new List<Genre>();

            foreach(var genre in book.Genres)
            {
                var genreFound = await _genreRepository
                    .GetByConditionAsync(genreLooked => genreLooked.Name == genre.Name);

                if (genreFound is null)
                {
                    genreFound = new Genre()
                    {
                        Name = genre.Name,
                        Description = genre.Description
                    };
                }

                bookMapped.Genres.Add(genreFound);
            }
            
            _bookRepository.Add(bookMapped);
            await _unitOfWork.SaveChangesAsync(cancellation);

            return _mapper.Map<BookDto>(bookMapped);
        }

        public async Task<string> DeleteAsync(int id, CancellationToken cancellation)
        {
            var book = await GetByIdAsync(id, cancellation);
            _bookRepository.Delete(book);
            await _unitOfWork.SaveChangesAsync(cancellation);

            return "book has been deleted";
        }

        public async Task<List<BookDto>> GetAllAsync(CancellationToken cancellation)
        {
            var books = await _bookRepository.GetAllAsync(cancellation);

            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<BookDto> UpdateAsync(int id, BookRequest book, CancellationToken cancellation)
        {
            var bookFound = await GetByIdAsync(id, cancellation);

            bookFound.Name = book.Name;
            bookFound.BookImage = book.BookImage;
            bookFound.Author = book.Author;
            bookFound.EditionHouseId = book.EditionHouseID;
            bookFound.EditionYear = book.EditionYear;
            bookFound.Price = book.Price;

            bookFound.Genres = new List<Genre>();

            foreach (var genre in book.Genres)
            {
                var genreFound = await _genreRepository
                    .GetByConditionAsync(genreLooked => genreLooked.Name == genre.Name);

                if (genreFound is null)
                {
                    genreFound = new Genre()
                    {
                        Name = genre.Name,
                        Description = genre.Description
                    };
                }

                bookFound.Genres.Add(genreFound);
            }


            _bookRepository.Update(bookFound);
           await _unitOfWork.SaveChangesAsync(cancellation);

            return _mapper.Map<BookDto>(bookFound);
        }

        private async Task<Book> GetByIdAsync(int id, CancellationToken cancellation)
        {
            var bookFound = await _bookRepository.GetByIdAsync(id, cancellation);
            if (bookFound is not null)
                return bookFound;

            throw new NotFoundException("book  with this id not doesn't exist");
        }
    }
}
