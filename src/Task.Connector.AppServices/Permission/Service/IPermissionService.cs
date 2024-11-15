using Models = Task.Integration.Data.Models.Models;

namespace Task.Connector.AppServices.Permission.Service;

/// <summary>
/// Сервис прав доступа и ролей.
/// </summary>
public interface IPermissionService
{
    /// <summary>
    /// Получить все права и роли.
    /// </summary>
    /// <returns>Права и роли.</returns>
    IEnumerable<Models.Permission> GetAllPermissions();

    /// <summary>
    /// Добавить пользователю права/роль.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="rightIds">Коллекция идентификаторов прав/ролей.</param>
    void AddUserPermissions(string login, IEnumerable<string> rightIds);

    /// <summary>
    /// Получить права доступа/роль пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <returns>Коллекция идентификаторов прав/ролей.</returns>
    IEnumerable<string> GetUserPermissions(string login);

    /// <summary>
    /// Удалить права доступа/роль у пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="rightIds">Коллекция идентификаторов прав/ролей.</param>
    void RemoveUserPermissions(string login, IEnumerable<string> rightIds);
}
