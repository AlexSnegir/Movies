using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Movies.Application.Abstractions.ExternalServices;
using Movies.Application.Mappings;
using Movies.Infrastructure.ExternalServices.TmdbService;
using Movies.Infrastructure.ExternalServices.TmdbService.Tmdb.Settings;

namespace Movies.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TmdbSettings>(configuration.GetSection(TmdbSettings.SettingsKey));
        services.AddTransient<ITmdbService, TmdbService>();
        services.AddHttpClient<ITmdbService, TmdbService>(client =>
        {
            client.BaseAddress = new Uri(configuration["TheMovieDBApi:BaseAddress"]);
        });

        services.AddSingleton(provider =>
            new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TmdbProfile(provider.GetService<IOptions<TmdbSettings>>()));
                cfg.AddProfile(new ApplicationProfile());
            })
            .CreateMapper());

        return services;
    }
}
