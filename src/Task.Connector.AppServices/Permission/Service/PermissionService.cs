using Task.Connector.AppServices.Permission.Repository;
using Task.Connector.Contract.Permission;
using Task.Connector.Infrastructure.Common;
using Task.Connector.Infrastructure.Common.Enums;
using Task.Connector.Infrastructure.Extensions;
using Task.Integration.Data.Models;
using Models = Task.Integration.Data.Models.Models;


namespace Task.Connector.AppServices.Permission.Service;

/// <summary>
/// Сервис прав доступа и ролей.
/// </summary>
public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly ILogger? _logger;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="PermissionService"/>.
    /// </summary>
    /// <param name="permissionRepository">Репозиторий прав доступа и ролей.</param>
    /// <param name="logger">Логгер.</param>
    public PermissionService(IPermissionRepository permissionRepository, ILogger? logger)
    {
        _permissionRepository = permissionRepository;
        _logger = logger;
    }

    /// <inheritdoc />
    public IEnumerable<Models.Permission> GetAllPermissions()
    {
        _logger?.Debug("Выполняется получение всех прав доступа.");
        return _permissionRepository.GetAllPermissions();
    }

    /// <inheritdoc />
    public void AddUserPermissions(string login, IEnumerable<string> rightIds)
    {
        _logger?.Debug($"Выполняется добавление прав пользователю. Логин {login}");
        ExecuteAction(_permissionRepository.AddRight, login, rightIds);
    }

    /// <inheritdoc />
    public IEnumerable<string> GetUserPermissions(string login)
    {
        _logger?.Debug($"Выполняется получение прав доступа/ролей пользователя. Логин {login}");
        return _permissionRepository.GetUserPermissions(login);
    }

    /// <inheritdoc />
    public void RemoveUserPermissions(string login, IEnumerable<string> rightIds)
    {
        _logger?.Debug($"Выполняется удаление прав пользователю. Логин {login}");
        ExecuteAction(_permissionRepository.RemoveUserPermission, login, rightIds);
    }

    private void ExecuteAction(Action<RightDto> action, string login, IEnumerable<string> rightIds)
    {
        rightIds.ForEach(right =>
        {
            var data = right.Split(Delimiter.Default).ToArray();
            Enum.TryParse(data[0], out Permissions permission);
            _logger?.Debug(right);
            action(new RightDto
            {
                Login = login,
                RightId = int.Parse(data[1]),
                Permission = permission
            });
        });
    }
}
