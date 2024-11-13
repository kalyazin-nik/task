namespace Task.Connector.Contract.User;

public class UserAllPropertiesDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string TelephoneNumber { get; set; } = null!;
    public string IsLead { get; set; } = null!;
    public string Password { get; set; } = null!;
}
