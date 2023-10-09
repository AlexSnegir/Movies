namespace Movies.API.Contracts;

public sealed record GetWatchlistForUserRequest(
    int Page = 1,
    int Count = 20);