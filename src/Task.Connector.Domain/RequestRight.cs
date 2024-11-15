namespace Task.Connector.Domain;

public class RequestRight : EntityBase
{
    public required int Id { get; set; }
    public required string Name { get; set; }

    public virtual ICollection<UserRequestRight>? UserRequestRights { get; set; }
}
