using Microsoft.EntityFrameworkCore;
using Movies.Application.Abstractions.Repositories;
using Movies.Domain.Entities;

namespace Movies.Persistence.Repository;

internal sealed class WatchlistRepository :
    GenericRepository<Watchlist>, IWatchlistRepository<Watchlist>
{
    public WatchlistRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Watchlist>> GetWatchlistForUserAsync(
        int userId,
        CancellationToken cancellationToken = default)
    {
        return await context
            .Set<Watchlist>()
            .AsNoTracking()
            .Include(x => x.Movie.Genres)
            .Include(x => x.Movie.BelongsToCollection)
            .Include(x => x.Movie.ProductionCompanies)
            .Include(x => x.Movie.ProductionCountries)
            .Include(x => x.Movie.SpokenLanguages)
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}