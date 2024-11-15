using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Task.Connector.Domain;
using Task.Integration.Data.Models;

namespace Task.Connector.DataAccess.Repositories.Repository;

/// <summary>
/// Репозиторий.
/// </summary>
/// <typeparam name="TContext">Экземпляр класса <see cref="DbContext"/>.</typeparam>
public class Repository<TContext> : IRepository<TContext> where TContext : DbContext
{
    protected TContext DbContext;
    private readonly ILogger? _logger;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Repository"/>.
    /// </summary>
    /// <param name="dbContext">Контекст данных.</param>
    /// <param name="logger">Логгер.</param>
    public Repository(TContext dbContext, ILogger? logger)
    {
        DbContext = dbContext;
        _logger = logger;
    }

    /// <inheritdoc />
    public void Create<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        DbContext.Set<TEntity>().Add(entity);
        DbContext.SaveChanges();
    }

    /// <inheritdoc />
    public TEntity? Get<TEntity>(object id) where TEntity : EntityBase
    {
        return DbContext.Set<TEntity>().Find(id);
    }

    /// <inheritdoc />
    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : EntityBase
    {
        return DbContext.Set<TEntity>().AsQueryable();
    }

    /// <inheritdoc />
    public IQueryable<TEntity> GetByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase
    {
        return DbContext.Set<TEntity>().Where(predicate).AsQueryable();
    }

    /// <inheritdoc />
    public void Remove<TEntity>(object id) where TEntity : EntityBase
    {
        if (DbContext.Set<TEntity>().Find(id) is TEntity entity)
        {
            Remove(entity);
        }
    }

    /// <inheritdoc />
    public void Remove<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        DbContext.Set<TEntity>().Remove(entity);
        DbContext.SaveChanges();
    }

    /// <inheritdoc />
    public void RemoveByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase
    {
        if (GetByPredicate(predicate).FirstOrDefault() is TEntity entity)
        {
            Remove(entity);
        }
    }

    /// <inheritdoc />
    public void Update<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        DbContext.Set<TEntity>().Update(entity);
        DbContext.SaveChanges();
    }
}
