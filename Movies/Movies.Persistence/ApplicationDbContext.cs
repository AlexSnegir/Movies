using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using System.Reflection;

namespace Movies.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<ProductionCompany> ProductionCompanies { get; set; }
    public DbSet<ProductionCountry> ProductionCountries { get; set; }
    public DbSet<SpokenLanguage> SpokenLanguages { get; set; }

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}