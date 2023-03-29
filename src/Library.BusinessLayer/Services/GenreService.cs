using AutoMapper;
using Library.BusinessLayer.DTO_s;
using Library.BusinessLayer.Exceptions;
using Library.BusinessLayer.Requests;
using Library.BusinessLayer.Services.Interfaces;
using Library.DataAccess.Models;
using Library.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Library.BusinessLayer.Services;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;
    private ILogger<GenreService> _logger;
    private IUnitOfWork _unitOfWork;

    public GenreService(IGenreRepository genreRepository, IMapper mapper,
        ILogger<GenreService> logger,
        IUnitOfWork unitOfWork)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<GenreDto> AddAsync(GenreRequest genre, CancellationToken cancellation)
    {
        var genreMapped = _mapper.Map<Genre>(genre);

        _genreRepository.Add(genreMapped);
        await _unitOfWork.SaveChangesAsync(cancellation);

        return _mapper.Map<GenreDto>(genreMapped);
    }

    public async Task<string> DeleteAsync(int id, CancellationToken cancellation)
    {
        var genreFound = await GetByIdAsync(id, cancellation);

        _genreRepository.Delete(genreFound);
        await _unitOfWork.SaveChangesAsync(cancellation);

        return "has been deleted";
    }

    public async Task<List<GenreDto>> GetAllAsync(CancellationToken cancellation)
    {
       var genres = await _genreRepository.GetGenresAsync(cancellation);
        return _mapper.Map<List<GenreDto>>(genres);
    }

    public async Task<GenreDto> UpdateAsync(int id, GenreRequest genre, CancellationToken cancellation)
    {
        var genreFound = await GetByIdAsync(id, cancellation);

        genreFound.Name = genre.Name;
        genreFound.Description = genre.Description;

        _genreRepository.Update(genreFound);
        await _unitOfWork.SaveChangesAsync(cancellation);

        return _mapper.Map<GenreDto>(genreFound);
    }

    private async Task<Genre> GetByIdAsync(int id, CancellationToken cancellation)
    {
        var genreFound = await _genreRepository.GetGenreByIdAsync(id, cancellation);

        if (genreFound is not null)
            return genreFound;

        _logger.LogError("id of genre not found");

        throw new NotFoundException("genre with this id does not exist");
    }

}
