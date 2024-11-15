using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Task.Connector.Domain;

namespace Task.Connector.DataAccess.Repositories.Repository;

/// <summary>
/// Репозиторий.
/// </summary>
/// <typeparam name="TContext">Экземпляр класса <see cref="DbContext"/>.</typeparam>
public interface IRepository<TContext> where TContext : DbContext
{
    /// <summary>
    /// Создать сущность, наследуюмую от <see cref="EntityBase"/>.
    /// </summary>
    /// <typeparam name="TEntity">Экземпляр класса <see cref="EntityBase"/>.</typeparam>
    /// <param name="entity">Сущность наследуемая от <see cref="EntityBase"/>.</param>
    void Create<TEntity>(TEntity entity) where TEntity : EntityBase;

    /// <summary>
    /// Получить сущность, наследуюмую от <see cref="EntityBase"/>.
    /// </summary>
    /// <typeparam name="TEntity">Экземпляр класса <see cref="EntityBase"/>.</typeparam>
    /// <param name="id">идентификатор.</param>
    /// <returns></returns>
    TEntity? Get<TEntity>(object id) where TEntity : EntityBase;

    /// <summary>
    /// Получить коллекцию всех сущностей, наследуемых от <see cref="EntityBase"/>.
    /// </summary>
    /// <typeparam name="TEntity">Экземпляр класса <see cref="EntityBase"/>.</typeparam>
    /// <returns></returns>
    IQueryable<TEntity> GetAll<TEntity>() where TEntity : EntityBase;

    /// <summary>
    /// Получить коллекцию сущностей по условию, наследуемых от <see cref="EntityBase"/>.
    /// </summary>
    /// <typeparam name="TEntity">Экземпляр класса <see cref="EntityBase"/>.</typeparam>
    /// <param name="predicate">Условие.</param>
    /// <returns></returns>
    IQueryable<TEntity> GetByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase;

    /// <summary>
    /// Удалить сущность, наследуюмую от <see cref="EntityBase"/>.
    /// </summary>
    /// <typeparam name="TEntity">Экземпляр класса <see cref="EntityBase"/>.</typeparam>
    /// <param name="id">идентификатор.</param>
    void Remove<TEntity>(object id) where TEntity : EntityBase;

    /// <summary>
    /// Удалить сущность, наследуюмую от <see cref="EntityBase"/>.
    /// </summary>
    /// <typeparam name="TEntity">Экземпляр класса <see cref="EntityBase"/>.</typeparam>
    /// <param name="entity">Сущность наследуемая от <see cref="EntityBase"/>.</param>
    void Remove<TEntity>(TEntity entity) where TEntity : EntityBase;

    /// <summary>
    /// Удаление сущности по условию, наследуюмой от <see cref="EntityBase"/>.
    /// </summary>
    /// <typeparam name="TEntity">Экземпляр класса <see cref="EntityBase"/>.</typeparam>
    /// <param name="predicate">Условие.</param>
    void RemoveByPredicate<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : EntityBase;

    /// <summary>
    /// Обновить сущность, наследуюмую от <see cref="EntityBase"/>.
    /// </summary>
    /// <typeparam name="TEntity">Экземпляр класса <see cref="EntityBase"/>.</typeparam>
    /// <param name="entity">Сущность наследуемая от <see cref="EntityBase"/>.</param>
    void Update<TEntity>(TEntity entity) where TEntity : EntityBase;
}
