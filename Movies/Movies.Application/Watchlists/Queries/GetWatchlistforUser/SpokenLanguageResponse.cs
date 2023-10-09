namespace Movies.Application.Watchlists.Queries.GetWatchlistforUser;

public sealed record class SpokenLanguageResponse
{
    public string IsoCode { get; set; }
    public string Name { get; set; }
    public string EnglishName { get; set; }
}