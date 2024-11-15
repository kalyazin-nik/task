namespace Task.Connector.Domain;

public class UserItRole : EntityBase
{
    public required string UserId { get; set; }
    public required int RoleId { get; set; }

    public virtual User? User { get; set; }
    public virtual ItRole? ItRole { get; set; }
}
