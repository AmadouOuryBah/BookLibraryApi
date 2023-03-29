using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations
{
    public class EditionHouseConfuguration : IEntityTypeConfiguration<EditionHouse>
    {
        public void Configure(EntityTypeBuilder<EditionHouse> builder)
        {
            builder.HasKey(ed => ed.Id);
            builder.Property(ed => ed.Id)
                .ValueGeneratedOnAdd();

            builder.Property(ed => ed.City)
                .IsRequired();
            builder.Property(ed => ed.Address)
                .IsRequired();

            builder.ToTable("EditionsHouses");
        }
    }
}
