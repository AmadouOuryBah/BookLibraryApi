using Library.DataAccess.Models;

namespace Library.DataAccess.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync(CancellationToken cancellation);
        Task<Book> GetByIdAsync(int id, CancellationToken cancellation);
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);
    }
}

