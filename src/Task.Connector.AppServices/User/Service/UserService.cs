using AutoMapper;
using Task.Connector.AppServices.User.Repository;
using Task.Connector.Contract.User;
using Task.Connector.Infrastructure.Extensions;
using Task.Integration.Data.Models;
using Task.Integration.Data.Models.Models;

namespace Task.Connector.AppServices.User.Service;

/// <summary>
/// Сервис пользователя.
/// </summary>
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ILogger? _logger;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="UserService"/>.
    /// </summary>
    /// <param name="userRepository">Репозиторий пользователя.</param>
    /// <param name="mapper">Маппер.</param>
    /// <param name="logger">Логгер.</param>
    public UserService(IUserRepository userRepository, IMapper mapper, ILogger? logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <inheritdoc />
    public void Create(UserToCreate userToCreate)
    {
        if (!IsExist(userToCreate.Login))
        {
            var model = _mapper.Map<UserDto>(userToCreate);
            userToCreate.Properties.ForEach(x => model[x.Name] = x.Value);

            _userRepository.Create(model);
        }
    }

    /// <inheritdoc />
    public bool IsExist(string login)
    {
        return _userRepository.IsExist(login);
    }

    /// <inheritdoc />
    public IEnumerable<Property> GetAllProperties()
    {
        return typeof(UserAllPropertiesDto)
            .GetProperties()
            .Select(x => new Property(x.Name, string.Empty))
            .ToList();
    }

    /// <inheritdoc />
    public IEnumerable<UserProperty> GetUserProperties(string login)
    {
        var properties = new List<UserProperty>();
        var model = _userRepository.GetUserPropertiesDto(login);
        typeof(UserPropertiesDto)
            .GetProperties()
            .Where(x => x.GetIndexParameters().Length == 0)
            .ForEach(x => properties.Add(new(x.Name, x.GetValue(model)?.ToString() ?? string.Empty)));

        return properties;
    }

    /// <inheritdoc />
    public void UpdateUserProperties(string login, IEnumerable<UserProperty> properties)
    {
        var model = new UserPropertiesDto();
        properties.ForEach(x => model[x.Name] = x.Value);
        _userRepository.Update(login, model);
    }
}
