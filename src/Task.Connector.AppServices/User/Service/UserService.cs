using AutoMapper;
using Task.Connector.AppServices.User.Repository;
using Task.Connector.Contract.User;
using Task.Connector.Infrastructure.Extensions;
using Task.Integration.Data.Models;
using Task.Integration.Data.Models.Models;

namespace Task.Connector.AppServices.User.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger? _logger;

    public UserService(IUserRepository userRepository, IMapper mapper, ILogger? logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public void CreateAsync(UserToCreate userToCreate)
    {
        if (!IsExistAsync(userToCreate.Login))
        {
            var model = _mapper.Map<UserDto>(userToCreate);
            userToCreate.Properties.ForEach(x => model[x.Name] = x.Value);

            _userRepository.CreateAsync(model);
        }
    }

    public bool IsExistAsync(string login)
    {
        return _userRepository.IsExistAsync(login);
    }

    public IEnumerable<Property> GetAllProperties()
    {
        return typeof(UserAllPropertiesDto)
            .GetProperties()
            .Select(x => new Property(x.Name, string.Empty))
            .ToList();
    }

    public IEnumerable<UserProperty> GetUserPropertiesAsync(string login)
    {
        var properties = new List<UserProperty>();
        var model = _userRepository.GetUserPropertiesDtoAsync(login);
        typeof(UserPropertiesDto)
            .GetProperties()
            .Where(x => x.GetIndexParameters().Length == 0)
            .ForEach(x => properties.Add(new(x.Name, x.GetValue(model)?.ToString() ?? string.Empty)));

        return properties;
    }

    public void UpdateUserProperties(string login, IEnumerable<UserProperty> properties)
    {
        var model = new UserPropertiesDto();
        properties.ForEach(x => model[x.Name] = x.Value);
        _userRepository.UpdateAsync(login, model);
    }
}
