using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Task.Connector.Domain;
using Tasks = System.Threading.Tasks;

namespace Task.Connector.Infrastructure.Repository;

public class Repository<TContext> : IRepository<TContext> where TContext : DbContext
{
    protected TContext DbContext;

    public Repository(TContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Tasks.Task CreateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : EntityBase
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity?> FindAsync<TEntity>(object id, CancellationToken cancellationToken) where TEntity : EntityBase
    {
        return await DbContext.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : EntityBase
    {
        return DbContext.Set<TEntity>().AsQueryable();
    }

    public IQueryable<TEntity> GetByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase
    {
        return DbContext.Set<TEntity>().Where(predicate).AsQueryable();
    }

    public async Tasks.Task RemoveAsync<TEntity>(object id, CancellationToken cancellationToken) where TEntity : EntityBase
    {
        if (await DbContext.Set<TEntity>().FindAsync(id, cancellationToken) is TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Tasks.Task RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : EntityBase
    {
        DbContext.Set<TEntity>().Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Tasks.Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : EntityBase
    {
        DbContext.Set<TEntity>().Update(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
