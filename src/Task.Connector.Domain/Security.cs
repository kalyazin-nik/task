namespace Task.Connector.Domain;

public class Security : EntityBase
{
    public int Id { get; set; }
    public required string UserId { get; set; }
    public required string Password { get; set; }
    public virtual User? User { get; set; }
}
