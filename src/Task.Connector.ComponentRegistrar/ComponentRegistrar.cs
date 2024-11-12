using Microsoft.Extensions.DependencyInjection;
using Task.Connector.AppServices.User.Repository;
using Task.Connector.AppServices.User.Service;
using Task.Connector.DataAccess.Repositories;
using Task.Connector.Infrastructure.Repository;
using Task.Connector.Infrastructure.Services.Logger;
using Task.Integration.Data.Models;

namespace Task.Connector.ComponentRegistrar;

public static class ComponentRegistrar
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<ILogger, FileLogger>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
