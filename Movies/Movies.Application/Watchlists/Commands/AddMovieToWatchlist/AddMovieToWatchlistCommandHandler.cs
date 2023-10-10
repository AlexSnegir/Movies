using Movies.Application.Abstractions.ExternalServices;
using Movies.Application.Abstractions.Messaging;
using Movies.Application.Abstractions.Repositories;
using Movies.Domain.Entities;
using Movies.Domain.Shared;

namespace Movies.Application.Watchlists.Commands.AddMovieToWatchlist;

internal sealed class AddMovieToWatchlistCommandHandler
    : ICommandHandler<AddMovieToWatchlistCommand>
{
    private readonly ITmdbService _tmdbService;
    private readonly IUnitOfWork _unitOfWork;

    public AddMovieToWatchlistCommandHandler(
        ITmdbService tmdbService,
        IUnitOfWork unitOfWork)
    {
        _tmdbService = tmdbService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddMovieToWatchlistCommand command, CancellationToken cancellationToken)
    {
        var query = new MovieDetailsQuery() { MovieId = command.MovieExternalId };
        var movieToAdd = await _tmdbService.MovieDetails(query, cancellationToken);

        if (movieToAdd is null)
        {
            return Result.Failure(
                new Error("Movie.NotFound", "Movie not found"));
        }

        MovieCollection movieCollection = null;
        var genreList = new List<Genre>();
        var productionCompanyList = new List<ProductionCompany>();
        var productionCountryList = new List<ProductionCountry>();
        var spokenLanguageList = new List<SpokenLanguage>();
        Movie movie = new();

        await PopulateMovieCollection(movieToAdd, movieCollection, cancellationToken);
        await PopulateGenres(movieToAdd, genreList, cancellationToken);
        await PopulateProductionCompanies(movieToAdd, productionCompanyList, cancellationToken);
        await PopulateProductionCountries(movieToAdd, productionCountryList, cancellationToken);
        await PopulateSpokenLanguages(movieToAdd, spokenLanguageList, cancellationToken);

        var movieResult = (await _unitOfWork.MovieRepository
            .FindAsync(x => x.ExternalId == movieToAdd.ExternalId, cancellationToken))
            .FirstOrDefault();

        if (movieResult is null)
        {
            movie.Id = movieToAdd.Id;
            movie.ExternalId = movieToAdd.ExternalId;
            movie.Adult = movieToAdd.Adult;
            movie.BelongsToCollection = movieCollection;
            movie.Budget = movieToAdd.Budget;
            movie.Genres = genreList;
            movie.Homepage = movieToAdd.Homepage;
            movie.ImdbId = movieToAdd.ImdbId;
            movie.OriginalLanguage = movieToAdd.OriginalLanguage;
            movie.OriginalTitle = movieToAdd.OriginalTitle;
            movie.Overview = movieToAdd.Overview;
            movie.Popularity = movieToAdd.Popularity;
            movie.PosterPath = movieToAdd.PosterPath;
            movie.ProductionCompanies = productionCompanyList;
            movie.ProductionCountries = productionCountryList;
            movie.ReleaseDate = movieToAdd.ReleaseDate;
            movie.Revenue = movieToAdd.Revenue;
            movie.Runtime = movieToAdd.Runtime;
            movie.SpokenLanguages = spokenLanguageList;
            movie.Status = movieToAdd.Status;
            movie.Tagline = movieToAdd.Tagline;
            movie.Title = movieToAdd.Title;
            movie.VoteAverage = movieToAdd.VoteAverage;
            movie.VoteCount = movieToAdd.VoteCount;
        }
        else
        {
            movie = movieResult;
        }

        var watchlist = new Watchlist()
        {
            UserId = command.UserId,
            IsWatched = false,
            Movie = movie
        };

        await _unitOfWork.WatchlistRepository.AddAsync(watchlist, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    private async Task PopulateMovieCollection(
        Movie movieToAdd,
        MovieCollection movieCollection,
        CancellationToken cancellationToken)
    {
        if (movieToAdd.BelongsToCollection is not null)
        {
            var result = (await _unitOfWork.MovieCollectionRepository
                .FindAsync(x => x.Id == movieToAdd.BelongsToCollection.Id, cancellationToken))
                .FirstOrDefault();

            if (result is null)
            {
                movieCollection = new()
                {
                    Id = movieToAdd.BelongsToCollection.Id,
                    Name = movieToAdd.BelongsToCollection.Name,
                    PosterPath = movieToAdd.BelongsToCollection.PosterPath
                };
            }
            else
            {
                movieCollection = result;
            }
        }
    }

    private async Task PopulateGenres(
        Movie movieToAdd,
        List<Genre> genreList,
        CancellationToken cancellationToken)
    {
        foreach (var genre in movieToAdd.Genres)
        {
            var result = (await _unitOfWork.GenreRepository
                .FindAsync(x => x.Id == genre.Id, cancellationToken))
                .FirstOrDefault();

            if (result is null)
            {
                genreList.Add(new Genre() { Id = genre.Id, Name = genre.Name });
            }
            else
            {
                genreList.Add(result);
            }
        }
    }

    private async Task PopulateProductionCompanies(
        Movie movieToAdd,
        List<ProductionCompany> productionCompanyList,
        CancellationToken cancellationToken)
    {
        foreach (var productionCompany in movieToAdd.ProductionCompanies)
        {
            var result = (await _unitOfWork.ProductionCompanyRepository
                .FindAsync(x => x.Id == productionCompany.Id, cancellationToken))
                .FirstOrDefault();

            if (result is null)
            {
                productionCompanyList.Add(new ProductionCompany()
                {
                    Id = productionCompany.Id,
                    LogoPath = productionCompany.LogoPath,
                    Name = productionCompany.Name,
                    OriginCountry = productionCompany.OriginCountry
                });
            }
            else
            {
                productionCompanyList.Add(result);
            }
        }
    }

    private async Task PopulateProductionCountries(
        Movie movieToAdd,
        List<ProductionCountry> productionCountryList,
        CancellationToken cancellationToken)
    {
        foreach (var productionCountry in movieToAdd.ProductionCountries)
        {
            var result = (await _unitOfWork.ProductionCountryRepository
                .FindAsync(x => x.IsoCode == productionCountry.IsoCode, cancellationToken))
                .FirstOrDefault();

            if (result is null)
            {
                productionCountryList.Add(new ProductionCountry()
                {
                    IsoCode = productionCountry.IsoCode,
                    Name = productionCountry.Name,
                });
            }
            else
            {
                productionCountryList.Add(result);
            }
        }
    }

    private async Task PopulateSpokenLanguages(
        Movie movieToAdd,
        List<SpokenLanguage> spokenLanguageList,
        CancellationToken cancellationToken)
    {
        foreach (var spokenLanguage in movieToAdd.SpokenLanguages)
        {
            var result = (await _unitOfWork.SpokenLanguageRepository
                .FindAsync(x => x.IsoCode == spokenLanguage.IsoCode, cancellationToken))
                .FirstOrDefault();

            if (result is null)
            {
                spokenLanguageList.Add(new SpokenLanguage()
                {
                    IsoCode = spokenLanguage.IsoCode,
                    Name = spokenLanguage.Name,
                });
            }
            else
            {
                spokenLanguageList.Add(result);
            }
        }
    }
}