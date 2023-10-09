namespace Movies.Domain.Entities;

public class SpokenLanguage
{
    public string IsoCode { get; set; }
    public string Name { get; set; }
    public string EnglishName { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}