using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;
using Movies.Persistence.Constants;

namespace Movies.Persistence.Configurations;

internal sealed class ProductionCompanyConfiguration : IEntityTypeConfiguration<ProductionCompany>
{
    public void Configure(EntityTypeBuilder<ProductionCompany> builder)
    {
        builder
            .ToTable(TableNames.ProductionCompanies)
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .Property(x => x.LogoPath)
            .HasColumnType(DbTypes.Varchar255)
            .IsRequired(false);

        builder
            .Property(x => x.Name)
            .HasColumnType(DbTypes.Varchar100)
            .IsRequired();

        builder
            .Property(x => x.OriginCountry)
            .HasColumnType(DbTypes.Char2)
            .IsRequired(false);
    }
}