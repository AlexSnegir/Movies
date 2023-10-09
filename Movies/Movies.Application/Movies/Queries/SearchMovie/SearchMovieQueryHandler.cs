using Movies.Application.Abstractions.ExternalServices;
using Movies.Application.Abstractions.Messaging;
using Movies.Domain.Shared;

namespace Movies.Application.Movies.Queries.SearchMovie;

internal sealed class SearchMovieQueryHandler
    : IQueryHandler<SearchMovieQuery, SearchMovieResponse>
{
    private readonly ITmdbService _tmdbService;

    public SearchMovieQueryHandler(ITmdbService tmdbService)
    {
        _tmdbService = tmdbService;
    }

    public async Task<Result<SearchMovieResponse>> Handle(
        SearchMovieQuery query,
        CancellationToken cancellationToken)
    {
        var searchedMovies = await _tmdbService.SearchMovie(query, cancellationToken);

        if (searchedMovies is null || searchedMovies.TotalResults == 0) 
        {
            return Result.Failure<SearchMovieResponse>(
                new Error("Movie.NotFound", "Movies not found"));
        }

        return searchedMovies;
    }
}