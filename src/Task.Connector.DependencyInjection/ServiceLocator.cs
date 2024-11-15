using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task.Connector.ComponentRegistrar;
using Task.Connector.DataAccess;
using Task.Connector.Infrastructure.DbModels;
using Task.Integration.Data.Models;

namespace Task.Connector.DependencyInjection;

/// <summary>
/// Локатор сервисов.
/// </summary>
public class ServiceLocator : IDisposable
{
    private bool _disposed = false;
    private IServiceProvider _serviceProvider;
    private string? _connectionString;
    private string? _provider;
    private string? _schema;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ServiceLocator"/> с заданной строкой подключения.
    /// </summary>
    /// <param name="dbConnection">Строка подключения к базе данных.</param>
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

    /// <summary>
    /// Получает сервис указанного типа.
    /// </summary>
    /// <typeparam name="TService">Тип сервиса.</typeparam>
    /// <returns>Экземпляр сервиса типа <typeparamref name="TService"/>.</returns>
    /// <exception cref="ArgumentNullException">Выбрасывается, если сервис не найден.</exception>
    public TService GetService<TService>()
    {
        var service = _serviceProvider.GetService<TService>();
        return service ?? throw new ArgumentNullException();
    }

    /// <summary>
    /// Получает сервис указанного типа с параметрами.
    /// </summary>
    /// <typeparam name="TService">Тип сервиса.</typeparam>
    /// <param name="parameters">Параметры для создания сервиса.</param>
    /// <returns>Экземпляр сервиса типа <typeparamref name="TService"/>.</returns>
    /// <exception cref="ArgumentNullException">Выбрасывается, если сервис не найден.</exception>
    public TService GetService<TService>(params object[] parameters)
    {
        var service = (TService)ActivatorUtilities.CreateInstance(_serviceProvider, typeof(TService), parameters);
        return service ?? throw new ArgumentNullException();
    }

    /// <summary>
    /// Высвобождает выделенные ресурсы для этого контекста.
    /// </summary>
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
