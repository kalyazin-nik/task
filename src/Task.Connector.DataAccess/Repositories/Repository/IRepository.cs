using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Task.Connector.Domain;

namespace Task.Connector.DataAccess.Repositories.Repository;

public interface IRepository<TContext> where TContext : DbContext
{
    void Create<TEntity>(TEntity entity) where TEntity : EntityBase;

    TEntity? Get<TEntity>(object id) where TEntity : EntityBase;

    IQueryable<TEntity> GetAll<TEntity>() where TEntity : EntityBase;

    IQueryable<TEntity> GetByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase;

    void Remove<TEntity>(object id) where TEntity : EntityBase;

    void Remove<TEntity>(TEntity entity) where TEntity : EntityBase;

    void RemoveByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase;

    void Update<TEntity>(TEntity entity) where TEntity : EntityBase;
}
