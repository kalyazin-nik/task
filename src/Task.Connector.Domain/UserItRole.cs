namespace Task.Connector.Domain;

/// <summary>
/// Связь пользователя и роли.
/// </summary>
public class UserItRole : EntityBase
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Идентификатор роли.
    /// </summary>
    public required int RoleId { get; set; }

    /// <summary>
    /// Пользователь.
    /// </summary>
    public virtual User? User { get; set; }

    /// <summary>
    /// Роль.
    /// </summary>
    public virtual ItRole? ItRole { get; set; }
}
