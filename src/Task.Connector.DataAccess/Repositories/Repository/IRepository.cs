using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Task.Connector.Domain;

namespace Task.Connector.DataAccess.Repositories.Repository;

public interface IRepository<TContext> where TContext : DbContext
{
    void CreateAsync<TEntity>(TEntity entity) where TEntity : EntityBase;

    TEntity? FindAsync<TEntity>(object id) where TEntity : EntityBase;

    IQueryable<TEntity> GetAll<TEntity>() where TEntity : EntityBase;

    IQueryable<TEntity> GetByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase;

    void RemoveAsync<TEntity>(object id) where TEntity : EntityBase;

    void RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase;

    void UpdateAsync<TEntity>(TEntity entity) where TEntity : EntityBase;
}
