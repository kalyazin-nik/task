using AutoMapper;
using Task.Connector.AppServices.User.Repository;
using Task.Connector.Contract.User;
using Task.Connector.Domain;
using Task.Connector.Infrastructure.Repository;

namespace Task.Connector.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IRepository<ConnectorDbContext> _repository;
    private readonly IMapper _mapper;

    public UserRepository(IRepository<ConnectorDbContext> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public void CreateAsync(UserDto model)
    {
        var user = _mapper.Map<User>(model);
        var security = _mapper.Map<Security>(model);
        user.Security = security;

        _repository.CreateAsync(user);
    }

    public bool IsExistAsync(string login)
    {
        return _repository.FindAsync<User>(login) is not null;
    }

    public UserDto GetUserDtoAsync(string login)
    {
        return _mapper.Map<UserDto>(_repository.FindAsync<User>(login));
    }

    public UserPropertiesDto GetUserPropertiesDtoAsync(string login)
    {
        return _mapper.Map<UserPropertiesDto>(_repository.FindAsync<User>(login));
    }

    public UserAllPropertiesDto GetUserAllPropertiesDtoAsync(string login)
    {
        return _mapper.Map<UserAllPropertiesDto>(_repository.FindAsync<User>(login));
    }

    public void UpdateAsync(string login, UserPropertiesDto model)
    {
        if (_repository.FindAsync<User>(login) is User user)
        {
            user.FirstName = string.IsNullOrWhiteSpace(model.FirstName) ? user.FirstName : model.FirstName;
            user.LastName = string.IsNullOrWhiteSpace(model.LastName) ? user.LastName : model.LastName;
            user.MiddleName = string.IsNullOrWhiteSpace(model.MiddleName) ? user.MiddleName : model.MiddleName;
            user.TelephoneNumber = string.IsNullOrWhiteSpace(model.TelephoneNumber) ? user.TelephoneNumber : model.TelephoneNumber;
            user.IsLead = string.IsNullOrWhiteSpace(model.IsLead) ? user.IsLead : bool.Parse(model.IsLead);

            _repository.UpdateAsync(user);
        }
    }
}
