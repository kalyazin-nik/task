using System.Reflection;

namespace Task.Connector.Domain;

public sealed class User : EntityBase
{
    private static readonly Dictionary<string, PropertyInfo> _properties = typeof(User)
        .GetProperties()
        .ToDictionary(k => k.Name.ToLower(), v => v);

    public required string Login { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string TelephoneNumber { get; set; } = string.Empty;
    public bool IsLead { get; set; }

    public object? this[string propertyName]
    {
        get => _properties[propertyName.ToLower()].GetValue(this);
        set => _properties[propertyName.ToLower()].SetValue(this, GetValueParse(propertyName, value));
    }

    private static object GetValueParse(string propertyName, object? obj)
    {
        if (IsBoolPropertyType(propertyName))
        {
            return IsBoolValue(obj);
        }

        return obj is string value ? value : string.Empty;
    }

    private static bool IsBoolPropertyType(string propertyName)
    {
        return _properties[propertyName.ToLower()].PropertyType == typeof(bool);
    }

    private static bool IsBoolValue(object? obj)
    {
        if (obj is string value)
        {
            return bool.Parse(value);
        }

        return false;
    }
}
