using Task.Connector.Contract.User;

namespace Task.Connector.AppServices.User.Repository;

public interface IUserRepository
{
    void CreateAsync(UserDto model);

    bool IsExistAsync(string login);

    UserDto GetUserDtoAsync(string login);

    UserPropertiesDto GetUserPropertiesDtoAsync(string login);

    UserAllPropertiesDto GetUserAllPropertiesDtoAsync(string login);

    void UpdateAsync(string login, UserPropertiesDto model);
}
