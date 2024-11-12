using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task.Connector.ComponentRegistrar;
using Task.Connector.DataAccess;
using Task.Connector.Infrastructure.Common.DbModels;

namespace Task.Connector.DependencyInjection;

public static class ServiceLocator
{
    private static string? _connectionString;
    private static string? _provider;
    private static string? _schema;
    private static IServiceProvider _serviceProvider;

    static ServiceLocator()
    {
        var services = new ServiceCollection();
        services.Configure<DbSchema>(options => options.Name = _schema);
        services.Configure<DbProvider>(options => options.Name = _provider);
        services.AddDbContext<ConnectorDbContext>(options => options.UseNpgsql(_connectionString));
        services.AddApplicationService();

        _serviceProvider = services.BuildServiceProvider();
    }

    public static void Initialize(DbConnectionStringBuilder dbConnection)
    {
        _connectionString = dbConnection["connectionstring"]?.ToString();
        _provider = dbConnection["provider"]?.ToString();
        _schema = dbConnection["schemaname"]?.ToString();
    }

    public static T GetService<T>()
    {
        var service = _serviceProvider.GetService<T>();
        return service ?? throw new ArgumentNullException();
    }

    public static T GetService<T>(params object[] parameters)
    {
        var service = (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), parameters);
        return service ?? throw new ArgumentNullException();
    }
}
