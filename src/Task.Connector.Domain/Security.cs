namespace Task.Connector.Domain;

/// <summary>
/// Обеспечение безопасности.
/// </summary>
public class Security : EntityBase
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// Пароль.
    /// </summary>
    public required string Password { get; set; }
    
    /// <summary>
    /// Пользователь.
    /// </summary>
    public virtual User? User { get; set; }
}
