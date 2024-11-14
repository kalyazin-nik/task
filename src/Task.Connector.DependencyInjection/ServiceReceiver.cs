using Task.Integration.Data.Models;

namespace Task.Connector.DependencyInjection;

public static class ServiceReceiver
{
    public static ILogger LoggerImplementation { internal get; set; } = null!;
}
