using Movies.Application.Abstractions.Messaging;

namespace Movies.Application.Watchlists.Queries.GetWatchlistforUser;

public sealed record GetWatchlistforUserQuery(int UserId, int Page = 1, int Count = 20)
    : IQuery<IEnumerable<GetWatchlistforUserResponse>>;