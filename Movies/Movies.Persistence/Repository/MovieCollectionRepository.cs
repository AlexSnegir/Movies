using Movies.Domain.Entities;

namespace Movies.Persistence.Repository;

internal sealed class MovieCollectionRepository : GenericRepository<MovieCollection>
{
    public MovieCollectionRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}