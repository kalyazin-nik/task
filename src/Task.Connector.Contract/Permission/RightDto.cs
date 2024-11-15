using Task.Connector.Infrastructure.Common.Enums;

namespace Task.Connector.Contract.Permission;

/// <summary>
/// Право доступа/роль.
/// </summary>
public class RightDto
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public required string Login { get; set; }

    /// <summary>
    /// Идентификатор права доступа/роли.
    /// </summary>
    public required int RightId { get; set; }

    /// <summary>
    /// Перечеслитель доступов.
    /// </summary>
    public required Permissions Permission { get; set; }
}
