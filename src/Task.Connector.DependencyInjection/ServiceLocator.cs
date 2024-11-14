using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task.Connector.ComponentRegistrar;
using Task.Connector.DataAccess;
using Task.Connector.Infrastructure.DbModels;
using Task.Integration.Data.Models;

namespace Task.Connector.DependencyInjection;

public class ServiceLocator : IDisposable
{
    private bool _disposed = false;
    private IServiceProvider _serviceProvider;
    private string? _connectionString;
    private string? _provider;
    private string? _schema;

    public ServiceLocator(DbConnectionStringBuilder dbConnection)
    {
        _connectionString = dbConnection["connectionstring"]?.ToString();
        _provider = dbConnection["provider"]?.ToString();
        _schema = dbConnection["schemaname"]?.ToString();

        var services = new ServiceCollection();
        services.Configure<DbSchema>(options => options.Name = _schema);
        services.Configure<DbProvider>(options => options.Name = _provider);
        services.AddDbContext<ConnectorDbContext>(options => options.UseNpgsql(_connectionString));
        services.AddSingleton<ILogger, ILogger>(serviceProvider => ServiceReceiver.LoggerImplementation);
        services.AddApplicationService();

        _serviceProvider = services.BuildServiceProvider();
    }

    public T GetService<T>()
    {
        var service = _serviceProvider.GetService<T>();
        return service ?? throw new ArgumentNullException();
    }

    public T GetService<T>(params object[] parameters)
    {
        var service = (T)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(T), parameters);
        return service ?? throw new ArgumentNullException();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            ServiceReceiver.LoggerImplementation = null!;
            var dbContext = _serviceProvider.GetService<ConnectorDbContext>();
            dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
