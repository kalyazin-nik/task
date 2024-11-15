namespace Task.Connector.Domain;

/// <summary>
/// Права доступа в системе.
/// </summary>
public class RequestRight : EntityBase
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
    /// Коллекция пользователей, которые обладают данным праваом доступа.
    /// </summary>
    public virtual ICollection<UserRequestRight>? UserRequestRights { get; set; }
}
