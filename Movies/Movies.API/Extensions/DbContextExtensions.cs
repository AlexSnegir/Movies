using Microsoft.EntityFrameworkCore;

namespace Movies.API.Extensions;

public static class DbContextExtensions
{
    public static IApplicationBuilder MigrateDatabase<TContext>(this IApplicationBuilder app)
        where TContext : DbContext
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();

            if (dbContext is null)
                throw new InvalidOperationException($"Could not resolve DbContext {typeof(TContext)}");

            dbContext.Database.Migrate();
        }

        return app;
    }
}