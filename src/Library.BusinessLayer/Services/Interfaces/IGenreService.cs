using Library.BusinessLayer.DTO_s;
using Library.BusinessLayer.Requests;
using Library.DataAccess.Models;

namespace Library.BusinessLayer.Services.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllAsync(CancellationToken cancellation);
        Task<GenreDto> AddAsync(GenreRequest genre, CancellationToken cancellation);
        Task<GenreDto> UpdateAsync(int id, GenreRequest genre, CancellationToken cancellation);
        Task<string> DeleteAsync(int id, CancellationToken cancellation);
    }
}
