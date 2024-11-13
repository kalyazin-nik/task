using System.Data.Common;
using Task.Connector.AppServices.User.Service;
using Task.Connector.DependencyInjection;
using Task.Integration.Data.Models;
using Task.Integration.Data.Models.Models;

namespace Task.Connector.Connector;

public class ConnectorDb : IConnector
{
    private const double SecondsTimeSpan = 15;
    private IUserService _userService = null!;

    public ILogger Logger { get; set; } = null!;

    /// <summary>
    /// Конфигурация коннектора через строку подключения.
    /// </summary>
    /// <param name="connectionString">Строка подключения.</param>
    public void StartUp(string connectionString)
    {
        var dbConnection = new DbConnectionStringBuilder { ConnectionString = connectionString };
        ServiceLocator.Initialize(dbConnection);

        _userService = ServiceLocator.GetService<IUserService>();
    }

    /// <summary>
    /// Создать пользователя с набором свойств по умолчанию.
    /// </summary>
    /// <param name="user">Модель создания пользователя.</param>
    public void CreateUser(UserToCreate user)
    {
        _userService.CreateAsync(user);
    }

    /// <summary>
    /// Проверка существования пользователя.
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <returns>Вернёт <see langword="true"/>, если пользователь существует, иначе <see langword="false"/>.</returns>
    public bool IsUserExists(string userLogin)
    {
        return _userService.IsExistAsync(userLogin);
    }

    /// <summary>
    /// Получение всех свойств пользователя.
    /// </summary>
    /// <returns>Коллекция свойств.</returns>
    public IEnumerable<Property> GetAllProperties()
    {
        return _userService.GetAllProperties();
    }

    /// <summary>
    /// Получить все значения свойств пользователяю.
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <returns>Коллекция значений.</returns>
    public IEnumerable<UserProperty> GetUserProperties(string userLogin)
    {
        return _userService.GetUserPropertiesAsync(userLogin);
    }

    /// <summary>
    /// Обновить значения свойств пользователя.
    /// </summary>
    /// <param name="properties">Коллекция свойств.</param>
    /// <param name="userLogin">Логин пользователя.</param>
    public void UpdateUserProperties(IEnumerable<UserProperty> properties, string userLogin)
    {
        _userService.UpdateUserProperties(userLogin, properties);
    }

    /// <summary>
    /// Получить все права в системе.
    /// </summary>
    /// <returns>Коллекция прав.</returns>
    public IEnumerable<Permission> GetAllPermissions() //  (смотри Описание системы клиента)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Добавить права пользователю в системе. 
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <param name="rightIds">Коллекция идентификаторв прав.</param>
    public void AddUserPermissions(string userLogin, IEnumerable<string> rightIds)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Удалить права пользователю в системе.
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <param name="rightIds">Коллекция идентификаторов прав.</param>
    public void RemoveUserPermissions(string userLogin, IEnumerable<string> rightIds)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Получить права пользователя в системе
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <returns>Коллекция идентификаторов прав.</returns>
    public IEnumerable<string> GetUserPermissions(string userLogin)
    {
        throw new NotImplementedException();
    }
}