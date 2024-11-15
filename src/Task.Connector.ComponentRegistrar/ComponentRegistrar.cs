using Microsoft.Extensions.DependencyInjection;
using Task.Connector.AppServices.Permission.Repository;
using Task.Connector.AppServices.Permission.Service;
using Task.Connector.AppServices.User.Repository;
using Task.Connector.AppServices.User.Service;
using Task.Connector.DataAccess.Repositories;
using Task.Connector.DataAccess.Repositories.Repository;

namespace Task.Connector.ComponentRegistrar;

public static class ComponentRegistrar
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPermissionService, PermissionService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
