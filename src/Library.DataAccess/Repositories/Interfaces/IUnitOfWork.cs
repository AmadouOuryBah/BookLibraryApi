

namespace Library.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellation); 
    }
}
