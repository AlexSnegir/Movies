using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;
using Movies.Persistence.Constants;

namespace Movies.Persistence.Configurations;

internal sealed class SpokenLanguageConfiguration : IEntityTypeConfiguration<SpokenLanguage>
{
    public void Configure(EntityTypeBuilder<SpokenLanguage> builder)
    {
        builder
            .ToTable(TableNames.SpokenLanguagies)
            .HasKey(x => x.IsoCode);

        builder
            .Property(x => x.Name)
            .HasColumnType(DbTypes.Nvarchar100)
            .IsRequired();

        builder
            .Property(x => x.EnglishName)
            .HasColumnType(DbTypes.Varchar100)
            .IsRequired(false);
    }
}