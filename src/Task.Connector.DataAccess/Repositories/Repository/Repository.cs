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
        _logger?.Debug("Сущность добавлена.");
        SaveChanges();
    }

    /// <inheritdoc />
    public TEntity? Get<TEntity>(object id) where TEntity : EntityBase
    {

        var entity = DbContext.Set<TEntity>().Find(id);
        _logger?.Debug("Поиск завершен.");
        if (entity is null)
        {
            _logger?.Warn("Сущность не найдена.");
        }

        return entity;
    }

    /// <inheritdoc />
    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : EntityBase
    {
        var entities = DbContext.Set<TEntity>().AsQueryable();
        _logger?.Debug("Поиск завершен.");
        return entities;
    }

    /// <inheritdoc />
    public IQueryable<TEntity> GetByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase
    {
        var entities = DbContext.Set<TEntity>().Where(predicate).AsQueryable();
        _logger?.Debug("Поиск завершен.");
        if (!entities.Any())
        {
            _logger?.Warn("Ни чего не найдено.");
        }

        return entities;

    }

    /// <inheritdoc />
    public void Remove<TEntity>(object id) where TEntity : EntityBase
    {
        _logger?.Debug($"Поиск сущности. Идентификатор: {id}");
        if (DbContext.Set<TEntity>().Find(id) is TEntity entity)
        {
            Remove(entity);
        }
    }

    /// <inheritdoc />
    public void Remove<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        DbContext.Set<TEntity>().Remove(entity);
        _logger?.Debug("Удаление выполнено.");
        SaveChanges();
    }

    /// <inheritdoc />
    public void RemoveByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase
    {
        _logger?.Debug($"Поиск сущности по условию.");
        if (GetByPredicate(predicate).FirstOrDefault() is TEntity entity)
        {
            Remove(entity);
        }
    }

    /// <inheritdoc />
    public void Update<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        DbContext.Set<TEntity>().Update(entity);
        _logger?.Debug("Обновление завершено.");
        SaveChanges();
    }

    private void SaveChanges()
    {
        try
        {
            DbContext.SaveChanges();
            _logger?.Debug("Изменения сохранены.");
        }
        catch (Exception ex)
        {
            _logger?.Error($"{ex.Message}");
        }
    }
}
