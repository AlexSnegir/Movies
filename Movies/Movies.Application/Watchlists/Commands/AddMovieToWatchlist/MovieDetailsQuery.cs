namespace Movies.Application.Watchlists.Commands.AddMovieToWatchlist;

public sealed record MovieDetailsQuery
{
    public int MovieId { get; set; }
    public string? AppendToResponse { get; set; } = null;
    public string Language { get; set; } = "en-US";
}