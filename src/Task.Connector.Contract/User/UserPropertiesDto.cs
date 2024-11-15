using System.Reflection;

namespace Task.Connector.Contract.User;

/// <summary>
/// Свойства пользователя.
/// </summary>
public class UserPropertiesDto
{
    private static readonly Dictionary<string, PropertyInfo> _properties = typeof(UserPropertiesDto)
        .GetProperties()
        .ToDictionary(k => k.Name.ToLower(), v => v);

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string? TelephoneNumber { get; set; }

    /// <summary>
    /// Является ли пользователь руководителем.
    /// </summary>
    public string? IsLead { get; set; }

    /// <summary>
    /// Обращение к свойствам пользователя через индексатор.
    /// </summary>
    /// <param name="propertyName">Название свойства пользователя.</param>
    /// <returns>Объект свойства пользователя.</returns>
    public object? this[string propertyName]
    {
        get => _properties[propertyName.ToLower()].GetValue(this);
        set => _properties[propertyName.ToLower()].SetValue(this, value?.ToString() ?? string.Empty);
    }
}
