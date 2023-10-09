using Movies.Domain.Entities;

namespace Movies.Persistence.Repository;

internal sealed class ProductionCountryRepository : GenericRepository<ProductionCountry>
{
    public ProductionCountryRepository(ApplicationDbContext context)
    : base(context)
    {
    }
}
