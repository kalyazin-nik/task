namespace Task.Connector.Domain;

public class UserRequestRight : EntityBase
{
    public required string UserId { get; set; }
    public required int RightId { get; set; }

    public virtual User? User { get; set; }
    public virtual RequestRight? RequestRight { get; set; }
}
