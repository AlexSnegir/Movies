using System.Text.Json.Serialization;

namespace Movies.Infrastructure.ExternalServices.Tmdb.Models.MovieDetails;

public sealed record SpokenLanguagesModel
{
    [JsonPropertyName("iso_639_1")] 
    public string IsoCode { get; set; }

    [JsonPropertyName("english_name")]
    public string EnglishName { get; set; }
    public string Name { get; set; }
}
