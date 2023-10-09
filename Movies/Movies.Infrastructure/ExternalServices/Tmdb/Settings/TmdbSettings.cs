namespace Movies.Infrastructure.ExternalServices.TmdbService.Tmdb.Settings;

public class TmdbSettings
{
    public const string SettingsKey = "TheMovieDBApi";

    public string ApiKey { get; set; }
    public string BaseAddress { get; set; }
    public string ImageBaseAddress { get; set; }
    public string MovieDetailsPath { get; set; }
    public string SearchMoviePath { get; set; }
}