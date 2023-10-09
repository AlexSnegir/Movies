namespace Movies.Domain.Entities;

public class Watchlist
{
    public int UserId { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public bool IsWatched { get; set; }
}