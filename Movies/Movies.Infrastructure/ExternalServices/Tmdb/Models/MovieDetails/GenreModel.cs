namespace Movies.Infrastructure.ExternalServices.Tmdb.Models.MovieDetails;

public sealed record GenreModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}