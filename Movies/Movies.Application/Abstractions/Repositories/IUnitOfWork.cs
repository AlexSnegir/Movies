using Movies.Domain.Entities;

namespace Movies.Application.Abstractions.Repositories;

public interface IUnitOfWork
{
    IRepository<Genre> GenreRepository { get; }
    IRepository<Movie> MovieRepository { get; }
    IRepository<MovieCollection> MovieCollectionRepository { get; }
    IRepository<ProductionCompany> ProductionCompanyRepository { get; }
    IRepository<ProductionCountry> ProductionCountryRepository { get; }
    IRepository<SpokenLanguage> SpokenLanguageRepository { get; }
    IWatchlistRepository<Watchlist> WatchlistRepository { get; }

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}