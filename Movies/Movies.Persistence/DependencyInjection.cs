using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Abstractions.Repositories;
using Movies.Domain.Entities;
using Movies.Persistence.Infrastructure;
using Movies.Persistence.Repository;

namespace Movies.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey);
        services.AddSingleton(new ConnectionString(connectionString));
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddTransient<IWatchlistRepository<Watchlist>, WatchlistRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}