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
        Logger = ServiceLocator.GetService<ILogger>();
    }

    /// <summary>
    /// Создать пользователя с набором свойств по умолчанию.
    /// </summary>
    /// <param name="user">Модель создания пользователя.</param>
    public async void CreateUser(UserToCreate user)
    {
        await _userService.CreateAsync(user, GetCancellationToken(SecondsTimeSpan));
    }

    /// <summary>
    /// Проверка существования пользователя.
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <returns>Вернёт <see langword="true"/>, если пользователь существует, иначе <see langword="false"/>.</returns>
    public bool IsUserExists(string userLogin)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Получение всех свойств пользователя.
    /// </summary>
    /// <returns>Коллекция свойств.</returns>
    public IEnumerable<Property> GetAllProperties() // Метод позволяет получить все свойства пользователя(смотри Описание системы), пароль тоже считать свойством
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Получить все значения свойств пользователяю.
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <returns>Коллекция значений.</returns>
    public IEnumerable<UserProperty> GetUserProperties(string userLogin)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Обновить значения свойств пользователя.
    /// </summary>
    /// <param name="properties">Коллекция свойств.</param>
    /// <param name="userLogin">Логин пользователя.</param>
    public void UpdateUserProperties(IEnumerable<UserProperty> properties, string userLogin)
    {
        throw new NotImplementedException();
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

    private static CancellationToken GetCancellationToken(double secondsTimeSpan)
    {
        return new CancellationTokenSource(TimeSpan.FromSeconds(secondsTimeSpan)).Token;
    }
}