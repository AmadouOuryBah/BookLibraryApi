using Library.DataAccess.Models;
using Library.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Library.DataAccess.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DbSet<Genre> _genres;
        private readonly ILogger<GenreRepository> _logger;

        public GenreRepository(LibraryContext context, ILogger<GenreRepository> logger)
        {
            _genres = context.Set<Genre>();
            _logger = logger;
        }
        public void Delete(Genre genre)
        {
            _genres.Remove(genre);
        }

        public Task<Genre?> GetGenreByIdAsync(int genreId, CancellationToken cancellation)
        {
            return _genres.Where(genre => genre.Id == genreId).FirstOrDefaultAsync(cancellation);
        }

        public Task<List<Genre>> GetGenresAsync(CancellationToken cancellation)
        {
            return _genres.ToListAsync(cancellation);
        }

        public void Add(Genre genre)
        {
            _genres.Add(genre);

            _logger.LogInformation($"The genre {genre.Name} has been added");

        }

        public void Update(Genre genre)
        {
            _genres.Update(genre);

            _logger.LogInformation($"The genre {genre.Name} has been updated");
        }

        public Task<Genre?> GetByConditionAsync(Expression<Func<Genre, bool>> options)
        {
            return _genres.Where(options).FirstOrDefaultAsync();
        }
    }
}
