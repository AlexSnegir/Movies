using Movies.Application.Abstractions.Messaging;

namespace Movies.Application.Watchlists.Commands.AddMovieToWatchlist;

public sealed record AddMovieToWatchlistCommand(int UserId, int MovieExternalId)
    : ICommand;