using System.Text.Json.Serialization;

namespace Movies.Infrastructure.ExternalServices.Tmdb.Models.MovieDetails;

public sealed record MovieDetailsModel
{
    public int Id { get; set; }
    public bool Adult { get; set; }
    public int Budget { get; set; }
    public List<GenreModel> Genres { get; set; }
    public string Homepage { get; set; }
    public string Overview { get; set; }
    public float Popularity { get; set; }
    public int Revenue { get; set; }
    public int Runtime { get; set; }
    public string Status { get; set; }
    public string Tagline { get; set; }
    public string Title { get; set; }
    public bool Video { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string BackdropPath { get; set; }

    [JsonPropertyName("belongs_to_collection")]
    public BelongsToCollectionModel BelongsToCollection { get; set; }

    [JsonPropertyName("imdb_id")]
    public string ImdbId { get; set; }

    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; }

    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; set; }

    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; }

    [JsonPropertyName("production_companies")]
    public List<ProductionCompanyModel> ProductionCompanies { get; set; }

    [JsonPropertyName("production_countries")]
    public List<ProductionCountryModel> ProductionCountries { get; set; }

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }

    [JsonPropertyName("spoken_languages")]
    public List<SpokenLanguagesModel> SpokenLanguages { get; set; }

    [JsonPropertyName("vote_average")]
    public float VoteAverage { get; set; }

    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
}