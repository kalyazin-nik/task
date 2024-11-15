namespace Task.Connector.Domain;

/// <summary>
/// Роль в системе.
/// </summary>
public class ItRole : EntityBase
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Внутрикорпоративный номер телефона.
    /// </summary>
    public required string CorporatePhoneNumber { get; set; }

    /// <summary>
    /// Коллекция пользователей, кому присвоена данная роль.
    /// </summary>
    public virtual ICollection<UserItRole>? UserItRoles { get; set; }
}
