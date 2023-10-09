using Movies.Domain.Entities;

namespace Movies.Persistence.Repository;

internal sealed class GenreRepository : GenericRepository<Genre>
{
    public GenreRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}