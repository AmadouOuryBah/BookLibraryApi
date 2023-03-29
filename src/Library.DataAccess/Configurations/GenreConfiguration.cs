using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(genre => genre.Id);
            builder.Property(genre => genre.Id)
                .ValueGeneratedOnAdd();

            builder.Property(genre => genre.Name)
                .IsRequired();
            builder.Property(genre => genre.Description)
                .IsRequired();

            builder.HasMany(genre => genre.Books)
           .WithMany(book => book.Genres);

            builder.ToTable("Genres");
        }
    }
}
