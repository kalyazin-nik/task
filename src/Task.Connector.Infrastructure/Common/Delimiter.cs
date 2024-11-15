namespace Task.Connector.Infrastructure.Common;

/// <summary>
/// Разделитель.
/// </summary>
public struct Delimiter
{
    /// <summary>
    /// По умолчанию.
    /// </summary>
    public const string Default = ":";

    /// <summary>
    /// Значение.
    /// </summary>
    public const string Value = ":[VALUE]:";

    /// <summary>
    /// Следование.
    /// </summary>
    public const string Trace = ":[TRACE]:";
}
