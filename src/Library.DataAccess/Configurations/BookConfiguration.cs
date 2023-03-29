using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(book => book.Id);
        builder.Property(book => book.Id)
            .ValueGeneratedOnAdd();

        builder.Property(book => book.Price)
            .IsRequired();

        builder.HasOne(book => book.EditionHouse)
            .WithMany(edition => edition.Books)
            .HasForeignKey(book => book.EditionHouseId);

        builder.HasMany(book => book.Genres)
            .WithMany(genre => genre.Books);

        builder.ToTable("Books");
    }
}
