using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;
using Movies.Persistence.Constants;

namespace Movies.Persistence.Configurations;

internal sealed class MovieCollectionConfiguration : IEntityTypeConfiguration<MovieCollection>
{
    public void Configure(EntityTypeBuilder<MovieCollection> builder)
    {
        builder
            .ToTable(TableNames.MovieCollections)
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Name)
            .HasColumnType(DbTypes.Varchar100)
            .IsRequired();

        builder
            .Property(x => x.PosterPath)
            .HasColumnType(DbTypes.Varchar255)
            .IsRequired(false);
    }
}