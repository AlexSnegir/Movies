using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;
using Movies.Persistence.Constants;

namespace Movies.Persistence.Configurations;

internal sealed class ProductionCountryConfiguration : IEntityTypeConfiguration<ProductionCountry>
{
    public void Configure(EntityTypeBuilder<ProductionCountry> builder)
    {
        builder
            .ToTable(TableNames.ProductionCountries)
            .HasKey(x => x.IsoCode);

        builder
            .Property(x => x.Name)
            .HasColumnType(DbTypes.Varchar100)
            .IsRequired();
    }
}