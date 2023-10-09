using Movies.Domain.Entities;

namespace Movies.Persistence.Repository;

internal sealed class MovieRepository : GenericRepository<Movie>
{
    public MovieRepository(ApplicationDbContext context)
        : base(context)
    {        
    }
}