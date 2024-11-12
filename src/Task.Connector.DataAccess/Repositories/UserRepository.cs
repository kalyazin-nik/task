using Task.Connector.AppServices.User.Repository;
using Task.Connector.Domain;
using Task.Connector.Infrastructure.Extensions;
using Task.Connector.Infrastructure.Repository;
using Task.Integration.Data.Models.Models;
using Tasks = System.Threading.Tasks;

namespace Task.Connector.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IRepository<ConnectorDbContext> _repository;

    public UserRepository(IRepository<ConnectorDbContext> repository)
    {
        _repository = repository;
    }

    public async Tasks.Task CreateAsync(UserToCreate model, CancellationToken cancellationToken)
    {
        var user = new User { Login = model.Login };
        var security = new Security { UserId = model.Login, Password = model.HashPassword };
        model.Properties.ForEach(x => user[x.Name] = x.Value);

        await _repository.CreateAsync(user, cancellationToken);
        await _repository.CreateAsync(security, cancellationToken);
    }
}
