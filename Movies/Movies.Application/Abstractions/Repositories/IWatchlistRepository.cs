namespace Movies.Application.Abstractions.Repositories;

public interface IWatchlistRepository<T> : IRepository<T>
    where T : class
{
    Task<IEnumerable<T>> GetWatchlistForUserAsync(
        int userId,
        CancellationToken cancellationToken = default);
}