using Movies.Application.Movies.Queries.SearchMovie;
using Movies.Application.Watchlists.Commands.AddMovieToWatchlist;
using Movies.Domain.Entities;

namespace Movies.Application.Abstractions.ExternalServices;

public interface ITmdbService
{
    Task<SearchMovieResponse?> SearchMovie(SearchMovieQuery query, CancellationToken cancellationToken);
    Task<Movie> MovieDetails(MovieDetailsQuery query, CancellationToken cancellationToken);
}