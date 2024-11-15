using Task.Connector.AppServices.Permission.Repository;
using Task.Connector.Contract.Permission;
using Task.Connector.DataAccess.Repositories.Repository;
using Task.Connector.Domain;
using Task.Connector.Infrastructure.Extensions;
using Task.Integration.Data.Models;
using Task.Integration.Data.Models.Models;

namespace Task.Connector.DataAccess.Repositories;

/// <summary>
/// Репозторий прав и ролей.
/// </summary>
public class PermissionRepository : IPermissionRepository
{
    private readonly IRepository<ConnectorDbContext> _repository;
    private readonly ILogger? _logger;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="PermissionRepository"/>.
    /// </summary>
    /// <param name="repository">Репозиторий.</param>
    /// <param name="logger">Логгер.</param>
    public PermissionRepository(IRepository<ConnectorDbContext> repository, ILogger? logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <inheritdoc />
    public IEnumerable<Permission> GetAllPermissions()
    {
        _logger?.Debug("Начался поиск прав/ролей в репозитории.");
        var permissions = new List<Permission>();

        _repository.GetAll<ItRole>()
            .ForEach(x => permissions.Add(new Permission(x.Id.ToString(), x.Name, x.CorporatePhoneNumber)));

        _repository.GetAll<RequestRight>()
            .ForEach(x => permissions.Add(new Permission(x.Id.ToString(), x.Name, string.Empty)));

        return permissions;
    }

    /// <inheritdoc />
    public void AddRight(RightDto right)
    {
        _logger?.Debug("Началось добавление прав/ролей пользователю в репозитории.");
        switch (right.Permission)
        {
            case Infrastructure.Common.Enums.Permissions.Role:
                _repository.Create(new UserItRole { RoleId = right.RightId, UserId = right.Login });
                return;
            case Infrastructure.Common.Enums.Permissions.Request:
                _repository.Create(new UserRequestRight { RightId = right.RightId, UserId = right.Login });
                return;
            default: throw new NotImplementedException();
        }
    }

    /// <inheritdoc />
    public IEnumerable<string> GetUserPermissions(string login)
    {
        _logger?.Debug("Начался поиск прав/ролей пользователя в репозитории.");
        return _repository.GetByPredicate<UserRequestRight>(x => x.UserId == login)
            .Select(x => x.RightId.ToString());
    }

    /// <inheritdoc />
    public void RemoveUserPermission(RightDto right)
    {
        _logger?.Debug("Началось удаление прав/ролей пользователя в репозитории.");
        switch (right.Permission)
        {
            case Infrastructure.Common.Enums.Permissions.Role:
                _repository.RemoveByPredicate<UserItRole>(x => x.UserId == right.Login && x.RoleId == right.RightId);
                return;
            case Infrastructure.Common.Enums.Permissions.Request:
                _repository.RemoveByPredicate<UserRequestRight>(x => x.UserId == right.Login && x.RightId == right.RightId);
                return;
            default: throw new NotImplementedException();
        }
    }
}
