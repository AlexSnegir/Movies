namespace Movies.Application.Watchlists.Queries.GetWatchlistforUser;

public sealed record ProductionCountryResponse
{
    public string IsoCode { get; set; }
    public string Name { get; set; }
}