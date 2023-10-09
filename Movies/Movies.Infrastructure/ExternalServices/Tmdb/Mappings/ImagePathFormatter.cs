using AutoMapper;
using Microsoft.Extensions.Options;
using Movies.Infrastructure.ExternalServices.TmdbService.Tmdb.Settings;

namespace Movies.Application.Mappings;

public class ImagePathFormatter : IValueConverter<string, string>
{
    private readonly TmdbSettings _tmdbSettings;

    public ImagePathFormatter(IOptions<TmdbSettings> tmdbOptions) =>
        _tmdbSettings = tmdbOptions.Value;

    public string Convert(string source, ResolutionContext context)
    {
        if (!string.IsNullOrWhiteSpace(source))
        {
            return $"{_tmdbSettings.ImageBaseAddress}{source}";
        }

        return source;
    }
}