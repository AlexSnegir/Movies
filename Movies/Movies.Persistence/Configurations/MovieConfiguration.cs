using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;
using Movies.Persistence.Constants;

namespace Movies.Persistence.Configurations;

internal sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder
            .ToTable(TableNames.Movies)
            .HasKey(x => x.Id);

        builder
            .HasIndex(x => x.ExternalId)
            .IsUnique();

        builder
            .Property(x => x.Adult)
            .IsRequired(false);

        builder
            .HasOne(x => x.BelongsToCollection)
            .WithMany();

        builder
            .Property(x => x.Budget)
            .IsRequired(false);

        builder
            .HasMany(x => x.Genres)
            .WithMany(x => x.Movies)
            .UsingEntity<MoviesGenres>(x => x
                .ToTable(TableNames.MoviesGenres));

        builder
            .Property(x => x.Homepage)
            .HasColumnType(DbTypes.Varchar255)
            .IsRequired(false);

        builder
            .Property(x => x.ImdbId)
            .HasColumnType(DbTypes.Varchar10)
            .IsRequired(false);

        builder
            .Property(x => x.OriginalLanguage)
            .HasColumnType(DbTypes.Char2)
            .IsRequired(false);

        builder
            .Property(x => x.OriginalTitle)
            .HasColumnType(DbTypes.Nvarchar100)
            .IsRequired(false);

        builder
            .Property(x => x.Overview)
            .HasColumnType(DbTypes.Varchar2000)
            .IsRequired(false);

        builder
            .Property(x => x.Popularity)
            .IsRequired(false);

        builder
            .Property(x => x.PosterPath)
            .HasColumnType(DbTypes.Varchar255)
            .IsRequired(false);

        builder
            .HasMany(x => x.ProductionCompanies)
            .WithMany(x => x.Movies)
            .UsingEntity<MoviesProductionCompanies>(x => x
                .ToTable(TableNames.MoviesProductionCompanies));

        builder
            .HasMany(x => x.ProductionCountries)
            .WithMany(x => x.Movies)
            .UsingEntity<Dictionary<string, object>>(TableNames.MoviesProductionCountries,
                x => x.HasOne<ProductionCountry>().WithMany().HasForeignKey("ProductionCountryIsoCode"),
                x => x.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                x => x.ToTable(TableNames.MoviesProductionCountries));

        builder
            .Property(x => x.ReleaseDate)
            .IsRequired(false);

        builder
            .Property(x => x.Revenue)
            .IsRequired(false);

        builder
            .Property(x => x.Runtime)
            .IsRequired(false);

        builder
            .HasMany(x => x.SpokenLanguages)
            .WithMany(x => x.Movies)
            .UsingEntity<Dictionary<string, object>>(TableNames.MoviesSpokenLanguages,
                x => x.HasOne<SpokenLanguage>().WithMany().HasForeignKey("SpokenLanguageIsoCode"),
                x => x.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                x => x.ToTable(TableNames.MoviesSpokenLanguages));

        builder
            .Property(x => x.Status)
            .HasColumnType(DbTypes.Varchar30)
            .IsRequired(false);

        builder
            .Property(x => x.Tagline)
            .HasColumnType(DbTypes.Varchar100)
            .IsRequired(false);

        builder
            .Property(x => x.Title)
            .HasColumnType(DbTypes.Varchar100)
            .IsRequired();

        builder
            .Property(x => x.VoteAverage)
            .IsRequired(false);

        builder
            .Property(x => x.VoteCount)
            .IsRequired(false);
    }
}