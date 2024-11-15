using Task.Connector.Contract.Permission;
using Models = Task.Integration.Data.Models.Models;

namespace Task.Connector.AppServices.Permission.Repository;

public interface IPermissionRepository
{
    IEnumerable<Models.Permission> GetAllPermissions();

    void AddRight(RightDto right);

    IEnumerable<string> GetUserPermissions(string login);

    void RemoveUserPermission(RightDto right);
}
