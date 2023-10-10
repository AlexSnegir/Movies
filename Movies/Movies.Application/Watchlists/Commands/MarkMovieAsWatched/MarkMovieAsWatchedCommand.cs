using Movies.Application.Abstractions.Messaging;

namespace Movies.Application.Watchlists.Commands.MarkMovieAsWatched;

public sealed record MarkMovieAsWatchedCommand(
    int UserId,
    int MovieId,
    bool IsWatched)
    : ICommand;