using Library.DataAccess.Models;
using Library.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DbSet<Book> books;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(LibraryContext context, ILogger<BookRepository> logger)
        {
             books = context.Set<Book>();
            _logger = logger;
        }
        public void Add(Book book)
        {
             books.Add(book);
            _logger.LogInformation($"The book {book.Name} has been added ");
        }

        public void Delete(Book book)
        {
            books.Remove(book);
            _logger.LogInformation($"The book {book.Name} has been deleted ");
        }

        public Task<List<Book>> GetAllAsync(CancellationToken cancellation)
        {
            return books.Include(book => book.Genres)
                .Include(book => book.EditionHouse)
                .ToListAsync(cancellation);
        }

        public Task<Book?> GetByIdAsync(int id, CancellationToken cancellation)
        {
            return books.Include(book => book.Genres)
                .Include(book => book.EditionHouse)
                .Where(book => book.Id == id)
                .FirstOrDefaultAsync(cancellation);
        }
        
        public void Update(Book book)
        {
             books.Update(book);
            _logger.LogInformation($"The book {book.Name} has been updated ");
        }
    }
}
