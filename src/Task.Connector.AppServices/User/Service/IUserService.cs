using Task.Integration.Data.Models.Models;

namespace Task.Connector.AppServices.User.Service;

/// <summary>
/// Сервис пользователя.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Создать пользователя.
    /// </summary>
    /// <param name="userToCreate">Модель создания пользователя.</param>
    void Create(UserToCreate userToCreate);

    /// <summary>
    /// Существует ли пользователь.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <returns>Вернет <see langword="true"/>, если запись пользователя создана, иначе <see langword="false"/>.</returns>
    bool IsExist(string login);

    /// <summary>
    /// Получить все свойства пользователя.
    /// </summary>
    /// <returns>Коллекция свойств пользователя.</returns>
    IEnumerable<Property> GetAllProperties();

    /// <summary>
    /// Получить свойства пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <returns>Свойства пользователя.</returns>
    IEnumerable<UserProperty> GetUserProperties(string login);

    /// <summary>
    /// Обновить значения свойств пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="properties">Коллекция свойств пользователя.</param>
    void UpdateUserProperties(string login, IEnumerable<UserProperty> properties);
}
