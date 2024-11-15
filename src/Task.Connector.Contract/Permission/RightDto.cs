using Task.Connector.Infrastructure.Common.Enums;

namespace Task.Connector.Contract.Permission;

public class RightDto
{
    public required string Login { get; set; }
    public required int RightId { get; set; }
    public required Permissions Permission { get; set; }
}
