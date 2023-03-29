using Library.DataAccess.Models;
using System.Linq.Expressions;

namespace Library.DataAccess.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetGenresAsync(CancellationToken cancellation);
        Task<Genre> GetGenreByIdAsync(int id, CancellationToken cancellation);
        Task<Genre> GetByConditionAsync(Expression<Func<Genre, bool>> options);
        void Add(Genre genre);
        void Delete(Genre genre);
        void Update(Genre genre);
       
    }
}
