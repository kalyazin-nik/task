namespace Task.Connector.Domain;

/// <summary>
/// Пользователь.
/// </summary>
public class User : EntityBase
{
    /// <summary>
    /// Логин, он же - идентификатор.
    /// </summary>
    public required string Login { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public required string MiddleName { get; set; }

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public required string TelephoneNumber { get; set; }

    /// <summary>
    /// Является ли пользователь руководителем.
    /// </summary>
    public bool IsLead { get; set; }

    /// <summary>
    /// Обеспечение безопасности
    /// </summary>
    public virtual Security? Security { get; set; }

    /// <summary>
    /// Коллекция ролей пользователя.
    /// </summary>
    public virtual ICollection<UserItRole>? UserItRoles { get; set; }

    /// <summary>
    /// Коллекция прав пользователя.
    /// </summary>
    public virtual ICollection<UserRequestRight>? UserRequestRights { get; set; }
}
