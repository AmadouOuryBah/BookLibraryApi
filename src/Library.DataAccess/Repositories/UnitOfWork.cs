using Library.DataAccess.Repositories.Interfaces;

namespace Library.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;

        public UnitOfWork(LibraryContext context)
        {
            _context = context;
        }

        public Task SaveChangesAsync(CancellationToken cancellation)
        {
            return _context.SaveChangesAsync(cancellation);
        }
    }
}
