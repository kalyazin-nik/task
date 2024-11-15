using Task.Connector.Contract.Permission;
using Models = Task.Integration.Data.Models.Models;

namespace Task.Connector.AppServices.Permission.Repository;

/// <summary>
/// Репозиторий прав и ролей.
/// </summary>
public interface IPermissionRepository
{
    /// <summary>
    /// Получить все права и роли.
    /// </summary>
    /// <returns>Права и роли.</returns>
    IEnumerable<Models.Permission> GetAllPermissions();

    /// <summary>
    /// Добавить право доступа/роль пользователю.
    /// </summary>
    /// <param name="right">Право доступа/роль</param>
    void AddRight(RightDto right);

    /// <summary>
    /// Получить права доступа/роль пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <returns>Коллекция идентификаторов прав/ролей.</returns>
    IEnumerable<string> GetUserPermissions(string login);

    /// <summary>
    /// Удалить право доступа/роль у пользователя.
    /// </summary>
    /// <param name="right">Право доступа/роль</param>
    void RemoveUserPermission(RightDto right);
}
