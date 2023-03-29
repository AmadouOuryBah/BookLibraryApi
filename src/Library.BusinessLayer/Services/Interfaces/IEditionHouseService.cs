using Library.BusinessLayer.DTO_s;
using Library.BusinessLayer.Requests;

namespace Library.BusinessLayer.Services.Interfaces
{
    public interface IEditionHouseService
    {
        Task<List<EditionHouseDto>> GetAllAsync(CancellationToken cancellation);
        Task<EditionHouseDto> AddAsync(EditionHouseRequest editionHouse, CancellationToken cancellation);
        Task<EditionHouseDto> UpdateAsync(int id, EditionHouseRequest editionHouse, CancellationToken cancellation);
        Task<string> DeleteAsync(int id, CancellationToken cancellation);
    }
}
