using System.Reflection;

namespace Task.Connector.Contract.User;

/// <summary>
/// Пользователь.
/// </summary>
public class UserDto
{
    private static readonly Dictionary<string, PropertyInfo> _properties = typeof(UserDto)
        .GetProperties()
        .ToDictionary(k => k.Name.ToLower(), v => v);

    /// <summary>
    /// Логин, он же - идентификатор.
    /// </summary>
    public string Login { get; set; } = string.Empty;

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Отчество.
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string TelephoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Является ли пользователь руководителем.
    /// </summary>
    public bool IsLead { get; set; }

    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Обращение к свойствам пользователя через индексатор.
    /// </summary>
    /// <param name="propertyName">Название свойства пользователя.</param>
    /// <returns>Объект свойства пользователя.</returns>
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
