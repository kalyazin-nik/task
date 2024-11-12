using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Task.Connector.Domain;
using Tasks = System.Threading.Tasks;

namespace Task.Connector.Infrastructure.Repository;

public interface IRepository<TContext> where TContext : DbContext
{
    Tasks.Task CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : EntityBase;

    Task<TEntity?> FindAsync<TEntity>(object id, CancellationToken cancellationToken) where TEntity : EntityBase;

    IQueryable<TEntity> GetAll<TEntity>() where TEntity : EntityBase;

    IQueryable<TEntity> GetByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase;

    Tasks.Task RemoveAsync<TEntity>(object id, CancellationToken cancellationToken) where TEntity : EntityBase;

    Tasks.Task RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : EntityBase;

    Tasks.Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : EntityBase;
}
