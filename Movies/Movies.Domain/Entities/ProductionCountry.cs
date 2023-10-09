namespace Movies.Domain.Entities;

public class ProductionCountry
{
    public string IsoCode { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}