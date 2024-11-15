using Task.Connector.Contract.User;

namespace Task.Connector.AppServices.User.Repository;

/// <summary>
/// Репозиторий пользователя.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Создать пользователя.
    /// </summary>
    /// <param name="model"></param>
    void Create(UserDto model);

    /// <summary>
    /// Существует ли пользователь.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <returns>Вернет <see langword="true"/>, если запись пользователя создана, иначе <see langword="false"/>.</returns>
    bool IsExist(string login);

    /// <summary>
    /// Получить пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <returns>Пользовател.</returns>
    UserDto GetUserDto(string login);

    /// <summary>
    /// Получить свойства пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <returns>Свойства пользователя.</returns>
    UserPropertiesDto GetUserPropertiesDto(string login);

    /// <summary>
    /// Получить все свойства пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <returns>Все свойства пользователя.</returns>
    UserAllPropertiesDto GetUserAllPropertiesDto(string login);

    /// <summary>
    /// Обновить пользователя.
    /// </summary>
    /// <param name="login">Логин.</param>
    /// <param name="model">Свойств пользователя.</param>
    void Update(string login, UserPropertiesDto model);
}
