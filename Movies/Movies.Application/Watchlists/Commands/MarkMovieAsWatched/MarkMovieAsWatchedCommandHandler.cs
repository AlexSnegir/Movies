using Movies.Application.Abstractions.Messaging;
using Movies.Application.Abstractions.Repositories;
using Movies.Domain.Entities;
using Movies.Domain.Shared;

namespace Movies.Application.Watchlists.Commands.MarkMovieAsWatched;

internal sealed class MarkMovieAsWatchedCommandHandler
    : ICommandHandler<MarkMovieAsWatchedCommand>
{
    private readonly IWatchlistRepository<Watchlist> _repository;

    public MarkMovieAsWatchedCommandHandler(IWatchlistRepository<Watchlist> repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(
        MarkMovieAsWatchedCommand request,
        CancellationToken cancellationToken)
    {
        var movieInWatchlist = (await _repository
            .FindAsync(x => x.UserId == request.UserId && x.MovieId == request.MovieId,
                cancellationToken))
            .SingleOrDefault();

        if (movieInWatchlist is null)
        {
            return Result.Failure(
                new Error(
                    "WatchlistMovie.NotFound",
                    "Movie in the watchlist not found"));
        }

        movieInWatchlist.IsWatched = request.IsWatched;
        _repository.Update(movieInWatchlist);
        await _repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}