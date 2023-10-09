using System.Text.Json.Serialization;

namespace Movies.Infrastructure.ExternalServices.Tmdb.Models.MovieDetails;

public sealed record ProductionCompanyModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonPropertyName("logo_path")]
    public string LogoPath { get; set; }

    [JsonPropertyName("origin_country")]
    public string OriginCountry { get; set; }
}