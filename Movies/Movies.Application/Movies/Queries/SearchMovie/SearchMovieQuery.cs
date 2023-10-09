using Movies.Application.Abstractions.Messaging;

namespace Movies.Application.Movies.Queries.SearchMovie;

public sealed record SearchMovieQuery(
    string Query,
    bool IncludeAdult,
    string Language,
    string? PrimaryReleaseYear,
    int Page,
    string? Region,
    string? Year) : IQuery<SearchMovieResponse>;