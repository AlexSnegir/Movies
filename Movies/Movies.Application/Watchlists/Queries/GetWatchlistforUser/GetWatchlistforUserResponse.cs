namespace Movies.Application.Watchlists.Queries.GetWatchlistforUser;

public sealed record GetWatchlistforUserResponse
{
    public MovieResponse Movie { get; set; }  
    public bool IsWatched { get; set; }
}