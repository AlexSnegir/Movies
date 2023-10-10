using System.Linq.Expressions;

namespace Movies.Application.Abstractions.Repositories;

public interface IRepository<T>
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    T Update(T entity);
    Task<IEnumerable<T>> AllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}