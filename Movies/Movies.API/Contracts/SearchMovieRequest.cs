namespace Movies.API.Contracts;

public sealed record SearchMovieRequest(
    string Query,
    bool IncludeAdult = false,
    int Page = 1,
    string? Region = null,
    string? Year = null);