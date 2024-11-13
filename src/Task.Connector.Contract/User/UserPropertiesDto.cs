using System.Reflection;

namespace Task.Connector.Contract.User;

public class UserPropertiesDto
{
    private static readonly Dictionary<string, PropertyInfo> _properties = typeof(UserPropertiesDto)
        .GetProperties()
        .ToDictionary(k => k.Name.ToLower(), v => v);

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? TelephoneNumber { get; set; }
    public string? IsLead { get; set; }

    public object? this[string propertyName]
    {
        get => _properties[propertyName.ToLower()].GetValue(this);
        set => _properties[propertyName.ToLower()].SetValue(this, value?.ToString() ?? string.Empty);
    }
}
