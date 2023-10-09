namespace Movies.Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    public int ExternalId { get; set; }
    public bool? Adult { get; set; }
    public MovieCollection? BelongsToCollection { get; set; }
    public int? Budget { get; set; }
    public virtual ICollection<Genre> Genres { get; set; }
    public string Homepage { get; set; }
    public string ImdbId { get; set; }
    public string OriginalLanguage { get; set; }
    public string OriginalTitle { get; set; }
    public string Overview { get; set; }
    public float? Popularity { get; set; }
    public string PosterPath { get; set; }
    public virtual ICollection<ProductionCompany> ProductionCompanies { get; set; }
    public virtual ICollection<ProductionCountry> ProductionCountries { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? Revenue { get; set; }
    public int? Runtime { get; set; }
    public virtual ICollection<SpokenLanguage> SpokenLanguages { get; set; }
    public string Status { get; set; }
    public string Tagline { get; set; }
    public string Title { get; set; }
    public float? VoteAverage { get; set; }
    public int? VoteCount { get; set; }
}