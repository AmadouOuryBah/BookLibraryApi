
using Library.DataAccess.Models;
using Library.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.DataAccess.Repositories
{
    public class EditionHouseRepository : IEditionHouseRepository
    {
        private readonly DbSet<EditionHouse> _editionHouses;
        private readonly ILogger<EditionHouseRepository> _logger;

        public EditionHouseRepository(LibraryContext context, ILogger<EditionHouseRepository> logger )
        {
            _editionHouses = context.Set<EditionHouse>();
            _logger = logger;

        }

        public void Add(EditionHouse editionHouse)
        {
            _editionHouses.Add(editionHouse);
        }

        public void Delete(EditionHouse editionHouse)
        {
            _editionHouses.Remove(editionHouse);
            _logger.LogInformation($"The editionHouse with the Address {editionHouse.Address} has been deleted");
        }

        public Task<List<EditionHouse>> GetAllAsync(CancellationToken cancellation)
        {
            return _editionHouses.ToListAsync(cancellation);
        }

        public Task<EditionHouse?> GetByIdAsync(int id, CancellationToken cancellation)
        {
            return _editionHouses.Where(editionHouse => editionHouse.Id == id).FirstOrDefaultAsync(cancellation);
        }

        public void Update(EditionHouse editionHouse)
        {
            _editionHouses.Update(editionHouse);
            _logger.LogInformation($"The editionHouse has been updated ");
        }
    }
}
