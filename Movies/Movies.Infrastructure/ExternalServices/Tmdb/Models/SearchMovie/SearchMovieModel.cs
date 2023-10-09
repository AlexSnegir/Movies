using System.Text.Json.Serialization;

namespace Movies.Infrastructure.ExternalServices.Tmdb.Models.SearchMovie;

public sealed record SearchMovieModel
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<MovieModel> Results { get; set; }

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }

    [JsonPropertyName("total_results")]
    public int TotalResults { get; set; }
}