using AutoMapper;
using Task.Connector.AppServices.User.Repository;
using Task.Connector.Contract.User;
using Task.Connector.Domain;
using Task.Connector.DataAccess.Repositories.Repository;
using Task.Integration.Data.Models;

namespace Task.Connector.DataAccess.Repositories;

/// <summary>
/// Репозиторий пользователя.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly IRepository<ConnectorDbContext> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger? _logger;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="UserRepository"/>.
    /// </summary>
    /// <param name="repository">Репозиторий.</param>
    /// <param name="mapper">Маппер.</param>
    /// <param name="logger">Логгер.</param>
    public UserRepository(IRepository<ConnectorDbContext> repository, IMapper mapper, ILogger? logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <inheritdoc />
    public void Create(UserDto model)
    {
        var user = _mapper.Map<User>(model);
        var security = _mapper.Map<Security>(model);
        user.Security = security;

        _repository.Create(user);
    }

    /// <inheritdoc />
    public bool IsExist(string login)
    {
        return _repository.Get<User>(login) is not null;
    }

    /// <inheritdoc />
    public UserDto GetUserDto(string login)
    {
        return _mapper.Map<UserDto>(_repository.Get<User>(login));
    }

    /// <inheritdoc />
    public UserPropertiesDto GetUserPropertiesDto(string login)
    {
        return _mapper.Map<UserPropertiesDto>(_repository.Get<User>(login));
    }

    /// <inheritdoc />
    public UserAllPropertiesDto GetUserAllPropertiesDto(string login)
    {
        return _mapper.Map<UserAllPropertiesDto>(_repository.Get<User>(login));
    }

    /// <inheritdoc />
    public void Update(string login, UserPropertiesDto model)
    {
        if (_repository.Get<User>(login) is User user)
        {
            user.FirstName = string.IsNullOrWhiteSpace(model.FirstName) ? user.FirstName : model.FirstName;
            user.LastName = string.IsNullOrWhiteSpace(model.LastName) ? user.LastName : model.LastName;
            user.MiddleName = string.IsNullOrWhiteSpace(model.MiddleName) ? user.MiddleName : model.MiddleName;
            user.TelephoneNumber = string.IsNullOrWhiteSpace(model.TelephoneNumber) ? user.TelephoneNumber : model.TelephoneNumber;
            user.IsLead = string.IsNullOrWhiteSpace(model.IsLead) ? user.IsLead : bool.Parse(model.IsLead);

            _repository.Update(user);
        }
    }
}
