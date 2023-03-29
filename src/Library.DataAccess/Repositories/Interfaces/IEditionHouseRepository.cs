using Library.DataAccess.Models;

namespace Library.DataAccess.Repositories.Interfaces
{
    public interface IEditionHouseRepository
    {
        Task<List<EditionHouse>> GetAllAsync(CancellationToken cancellation);
        Task<EditionHouse> GetByIdAsync(int id, CancellationToken cancellation);
        void Add(EditionHouse editionHouse);
        void Delete(EditionHouse editionHouse);
        void Update(EditionHouse editionHouse);
    }
}
