using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Task.Connector.Domain;

namespace Task.Connector.Infrastructure.Repository;

public class Repository<TContext> : IRepository<TContext> where TContext : DbContext
{
    protected TContext DbContext;

    public Repository(TContext dbContext)
    {
        DbContext = dbContext;
    }

    public void CreateAsync<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        DbContext.Set<TEntity>().Add(entity);
        DbContext.SaveChanges();
    }

    public TEntity? FindAsync<TEntity>(object id) where TEntity : EntityBase
    {
        return DbContext.Set<TEntity>().Find(id);
    }

    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : EntityBase
    {
        return DbContext.Set<TEntity>().AsQueryable();
    }

    public IQueryable<TEntity> GetByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase
    {
        return DbContext.Set<TEntity>().Where(predicate).AsQueryable();
    }

    public void RemoveAsync<TEntity>(object id) where TEntity : EntityBase
    {
        if (DbContext.Set<TEntity>().Find(id) is TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }
    }

    public void RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        DbContext.Set<TEntity>().Remove(entity);
        DbContext.SaveChanges();
    }

    public void UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        DbContext.Set<TEntity>().Update(entity);
        DbContext.SaveChanges();
    }
}
