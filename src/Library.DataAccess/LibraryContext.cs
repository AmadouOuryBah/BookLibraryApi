using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess
{
    public class LibraryContext: DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<EditionHouse> Editions { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(LibraryContext).Assembly);
        }

    }
}
