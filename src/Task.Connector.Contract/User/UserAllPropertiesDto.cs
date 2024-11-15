namespace Task.Connector.Contract.User;

/// <summary>
/// Все свойства пользователя.
/// </summary>
public class UserAllPropertiesDto
{
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Отчество.
    /// </summary>
    public string MiddleName { get; set; } = null!;

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string TelephoneNumber { get; set; } = null!;

    /// <summary>
    /// Является ли пользователь руководителем.
    /// </summary>
    public string IsLead { get; set; } = null!;

    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = null!;
}
