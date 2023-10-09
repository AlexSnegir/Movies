namespace Movies.Application.Watchlists.Queries.GetWatchlistforUser;

public sealed record ProductionCompanyResponse
{
    public int Id { get; set; }
    public string LogoPath { get; set; }
    public string Name { get; set; }
    public string OriginCountry { get; set; }
}