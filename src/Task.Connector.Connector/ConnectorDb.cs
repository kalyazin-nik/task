using System.Data.Common;
using Task.Connector.AppServices.Permission.Service;
using Task.Connector.AppServices.User.Service;
using Task.Connector.DependencyInjection;
using Task.Integration.Data.Models;
using Task.Integration.Data.Models.Models;

namespace Task.Connector.Connector;

/// <summary>
/// Подключение к базе данных.
/// </summary>
public class ConnectorDb : IConnector, IDisposable
{
    private bool _disposed = false;
    private ServiceLocator _serviceLocator = null!;
    private ILogger _logger = null!;

    /// <summary>
    /// Логгер.
    /// </summary>
    public ILogger Logger
    {
        get => _logger;
        set
        {
            _logger = value;
            LoggerChanged(_logger, new EventArgs());
        }
    }

    private event EventHandler LoggerChanged = null!;
    private void ProcessEventLoggerChanged(object sender, EventArgs e)
    {
        ServiceReceiver.LoggerImplementation = _logger;
    }

    /// <summary>
    /// Запуск подключения к базе данных через строку подключения.
    /// </summary>
    /// <param name="connectionString">Строка подключения.</param>
    public void StartUp(string connectionString)
    {
        LoggerChanged += ProcessEventLoggerChanged!;
        _serviceLocator = new ServiceLocator(new DbConnectionStringBuilder { ConnectionString = connectionString });
    }

    /// <summary>
    /// Создать пользователя с набором свойств по умолчанию.
    /// </summary>
    /// <param name="user">Модель создания пользователя.</param>
    public void CreateUser(UserToCreate user)
    {
        _serviceLocator.GetService<IUserService>().Create(user);
    }

    /// <summary>
    /// Проверка существования пользователя.
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <returns>Вернёт <see langword="true"/>, если пользователь существует, иначе <see langword="false"/>.</returns>
    public bool IsUserExists(string userLogin)
    {
        return _serviceLocator.GetService<IUserService>().IsExist(userLogin);
    }

    /// <summary>
    /// Получение всех свойств пользователя.
    /// </summary>
    /// <returns>Коллекция свойств.</returns>
    public IEnumerable<Property> GetAllProperties()
    {
        return _serviceLocator.GetService<IUserService>().GetAllProperties();
    }

    /// <summary>
    /// Получить все значения свойств пользователяю.
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <returns>Коллекция значений.</returns>
    public IEnumerable<UserProperty> GetUserProperties(string userLogin)
    {
        return _serviceLocator.GetService<IUserService>().GetUserProperties(userLogin);
    }

    /// <summary>
    /// Обновить значения свойств пользователя.
    /// </summary>
    /// <param name="properties">Коллекция свойств.</param>
    /// <param name="userLogin">Логин пользователя.</param>
    public void UpdateUserProperties(IEnumerable<UserProperty> properties, string userLogin)
    {
        _serviceLocator.GetService<IUserService>().UpdateUserProperties(userLogin, properties);
    }

    /// <summary>
    /// Получить все права в системе.
    /// </summary>
    /// <returns>Коллекция прав.</returns>
    public IEnumerable<Permission> GetAllPermissions() //  (смотри Описание системы клиента)
    {
        return _serviceLocator.GetService<IPermissionService>().GetAllPermissions();
    }

    /// <summary>
    /// Добавить права пользователю в системе. 
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <param name="rightIds">Коллекция идентификаторв прав.</param>
    public void AddUserPermissions(string userLogin, IEnumerable<string> rightIds)
    {
        _serviceLocator.GetService<IPermissionService>().AddUserPermissions(userLogin, rightIds);
    }

    /// <summary>
    /// Удалить права пользователю в системе.
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <param name="rightIds">Коллекция идентификаторов прав.</param>
    public void RemoveUserPermissions(string userLogin, IEnumerable<string> rightIds)
    {
        _serviceLocator.GetService<IPermissionService>().RemoveUserPermissions(userLogin, rightIds);
    }

    /// <summary>
    /// Получить права пользователя в системе
    /// </summary>
    /// <param name="userLogin">Логин пользователя.</param>
    /// <returns>Коллекция идентификаторов прав.</returns>
    public IEnumerable<string> GetUserPermissions(string userLogin)
    {
        return _serviceLocator.GetService<IPermissionService>().GetUserPermissions(userLogin);
    }

    /// <summary>
    /// Высвобождает выделенные ресурсы для этого контекста.
    /// </summary>
    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            _serviceLocator.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}