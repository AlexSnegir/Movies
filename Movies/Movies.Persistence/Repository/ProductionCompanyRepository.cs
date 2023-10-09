using Movies.Domain.Entities;

namespace Movies.Persistence.Repository;

internal sealed class ProductionCompanyRepository : GenericRepository<ProductionCompany>
{
    public ProductionCompanyRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}
