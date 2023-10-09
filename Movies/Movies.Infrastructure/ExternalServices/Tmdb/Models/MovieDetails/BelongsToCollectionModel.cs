using System.Text.Json.Serialization;

namespace Movies.Infrastructure.ExternalServices.Tmdb.Models.MovieDetails;

public sealed record BelongsToCollectionModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string BackdropPath { get; set; }
}