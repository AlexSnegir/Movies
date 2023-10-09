using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;
using Movies.Persistence.Constants;

namespace Movies.Persistence.Configurations;

internal sealed class WatchlistConfiguration : IEntityTypeConfiguration<Watchlist>
{
    public void Configure(EntityTypeBuilder<Watchlist> builder)
    {
        builder
            .ToTable(TableNames.Watchlists)
            .HasKey(x => new { x.UserId, x.MovieId });

        builder
            .Property(x => x.IsWatched)
            .IsRequired()
            .HasDefaultValue(false);

        builder
            .HasOne(x => x.Movie)
            .WithMany();
    }
}