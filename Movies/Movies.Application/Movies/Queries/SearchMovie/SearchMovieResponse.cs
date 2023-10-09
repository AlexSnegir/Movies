namespace Movies.Application.Movies.Queries.SearchMovie;

public sealed record SearchMovieResponse
{
    public int Page { get; set; }
    public List<MovieResponse> Movies { get; set; }
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
}