using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Movies.Application.Abstractions.Repositories;
using System.Linq.Expressions;

namespace Movies.Persistence.Repository;

public abstract class GenericRepository<T>
    : IRepository<T> where T : class
{
    protected ApplicationDbContext context;

    public GenericRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async virtual Task<T> AddAsync(
        T entity,
        CancellationToken cancellationToken)
    {
        var addedEntity = (await context.AddAsync(entity, cancellationToken)).Entity;

        return addedEntity;
    }

    public async virtual Task<IEnumerable<T>> AllAsync(
        CancellationToken cancellationToken)
    {
        var all = await context
            .Set<T>()
            .ToListAsync(cancellationToken);

        return all;
    }

    public async virtual Task<IEnumerable<T>> FindAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken)
    {
        var result = await context
            .Set<T>()
            .AsQueryable()
            .Where(predicate)
            .ToListAsync(cancellationToken);

        return result;
    }

    public virtual T Update(T entity)
    {
        return context
            .Update(entity).Entity;
    }

    public async virtual Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}