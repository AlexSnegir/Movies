using Movies.Application.Abstractions.Repositories;
using Movies.Domain.Entities;

namespace Movies.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    private IRepository<Genre> _genreRepository;
    public IRepository<Genre> GenreRepository
    {
        get
        {
            if (_genreRepository is null)
            {
                _genreRepository =
                    new GenreRepository(_context);
            }
            return _genreRepository;
        }
    }

    private IRepository<Movie> _movieRepository;
    public IRepository<Movie> MovieRepository
    {
        get
        {
            if (_movieRepository is null)
            {
                _movieRepository =
                    new MovieRepository(_context);
            }
            return _movieRepository;
        }
    }

    private IRepository<MovieCollection> _movieCollectionRepository;
    public IRepository<MovieCollection> MovieCollectionRepository
    {
        get
        {
            if (_movieCollectionRepository is null)
            {
                _movieCollectionRepository =
                    new MovieCollectionRepository(_context);
            }
            return _movieCollectionRepository;
        }
    }

    private IRepository<ProductionCompany> _productionCompanyRepository;
    public IRepository<ProductionCompany> ProductionCompanyRepository
    {
        get
        {
            if (_productionCompanyRepository is null)
            {
                _productionCompanyRepository =
                    new ProductionCompanyRepository(_context);
            }
            return _productionCompanyRepository;
        }
    }

    private IRepository<ProductionCountry> _productionCountryRepository;
    public IRepository<ProductionCountry> ProductionCountryRepository
    {
        get
        {
            if (_productionCountryRepository is null)
            {
                _productionCountryRepository =
                    new ProductionCountryRepository(_context);
            }
            return _productionCountryRepository;
        }
    }

    private IRepository<SpokenLanguage> _spokenLanguageRepository;
    public IRepository<SpokenLanguage> SpokenLanguageRepository
    {
        get
        {
            if (_spokenLanguageRepository is null)
            {
                _spokenLanguageRepository =
                    new SpokenLanguageRepository(_context);
            }
            return _spokenLanguageRepository;
        }
    }

    private IWatchlistRepository<Watchlist> _watchlistRepository;
    public IWatchlistRepository<Watchlist> WatchlistRepository
    {
        get
        {
            if (_watchlistRepository is null)
            {
                _watchlistRepository =
                    new WatchlistRepository(_context);
            }
            return _watchlistRepository;
        }
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);
}