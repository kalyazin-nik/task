using Models = Task.Integration.Data.Models.Models;

namespace Task.Connector.AppServices.Permission.Service;

public interface IPermissionService
{
    IEnumerable<Models.Permission> GetAllPermissions();

    void AddUserPermissions(string login, IEnumerable<string> rightIds);

    IEnumerable<string> GetUserPermissions(string login);

    void RemoveUserPermissions(string login, IEnumerable<string> rightIds);
}
