namespace Movies.Application.Watchlists.Queries.GetWatchlistforUser;

public sealed record GenreResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}