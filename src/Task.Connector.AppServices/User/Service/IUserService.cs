using Task.Integration.Data.Models.Models;

namespace Task.Connector.AppServices.User.Service;

public interface IUserService
{
    void CreateAsync(UserToCreate userToCreate);

    bool IsExistAsync(string login);

    IEnumerable<Property> GetAllProperties();

    IEnumerable<UserProperty> GetUserPropertiesAsync(string login);

    void UpdateUserProperties(string login, IEnumerable<UserProperty> properties);
}
