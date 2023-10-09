using System.Text.Json.Serialization;

namespace Movies.Infrastructure.ExternalServices.Tmdb.Models.MovieDetails;

public sealed record ProductionCountryModel
{
    [JsonPropertyName("iso_3166_1")]
    public string IsoCode { get; set; }
    public string Name { get; set; }
}