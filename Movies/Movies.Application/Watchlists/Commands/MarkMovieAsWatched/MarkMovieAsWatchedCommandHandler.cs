using MediatR;
using Movies.Application.Abstractions.Repositories;
using Movies.Domain.Entities;

namespace Movies.Application.Watchlists.Commands.MarkMovieAsWatched;

internal sealed class MarkMovieAsWatchedCommandHandler
    : IRequestHandler<MarkMovieAsWatchedCommand, MarkMovieAsWatchedResponse>
{
    private readonly IWatchlistRepository<Watchlist> _repository;

    public MarkMovieAsWatchedCommandHandler(IWatchlistRepository<Watchlist> repository)
    {
        _repository = repository;
    }

    public async Task<MarkMovieAsWatchedResponse> Handle(
        MarkMovieAsWatchedCommand request,
        CancellationToken cancellationToken)
    {
        var movieInWatchlist = (await _repository
            .FindAsync(x => x.UserId == request.UserId && x.MovieId == request.MovieId,
                cancellationToken))
            .SingleOrDefault();

        if (movieInWatchlist is null)
        {
            return await Task.FromResult(new MarkMovieAsWatchedResponse(false));
        }

        movieInWatchlist.IsWatched = request.IsWatched;
        _repository.Update(movieInWatchlist);
        await _repository.SaveChangesAsync(cancellationToken);

        return new MarkMovieAsWatchedResponse(true);
    }
}