using Task.Integration.Data.Models;

namespace Task.Connector.DependencyInjection;

/// <summary>
/// Приемник сервисов.
/// </summary>
public static class ServiceReceiver
{
    /// <summary>
    /// Реализация <see cref="ILogger"/>.
    /// </summary>
    public static ILogger LoggerImplementation { internal get; set; } = null!;
}
