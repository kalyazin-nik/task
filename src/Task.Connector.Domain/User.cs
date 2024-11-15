namespace Task.Connector.Domain;

public class User : EntityBase
{
    public required string Login { get; set; }
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public required string MiddleName { get; set; }
    public required string TelephoneNumber { get; set; }
    public bool IsLead { get; set; }

    public virtual Security? Security { get; set; }

    public virtual ICollection<UserItRole>? UserItRoles { get; set; }
    public virtual ICollection<UserRequestRight>? UserRequestRights { get; set; }
}
