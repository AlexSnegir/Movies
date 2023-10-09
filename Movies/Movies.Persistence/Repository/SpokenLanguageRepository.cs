using Movies.Domain.Entities;

namespace Movies.Persistence.Repository;

internal sealed class SpokenLanguageRepository : GenericRepository<SpokenLanguage>
{
    public SpokenLanguageRepository(ApplicationDbContext context)
    : base(context)
    {
    }
}