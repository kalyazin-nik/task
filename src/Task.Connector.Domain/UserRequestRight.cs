namespace Task.Connector.Domain;

/// <summary>
/// Связь пользователя и права доступа.
/// </summary>
public class UserRequestRight : EntityBase
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Идентификатор права.
    /// </summary>
    public required int RightId { get; set; }

    /// <summary>
    /// Пользователь.
    /// </summary>
    public virtual User? User { get; set; }

    /// <summary>
    /// Право доступа.
    /// </summary>
    public virtual RequestRight? RequestRight { get; set; }
}
