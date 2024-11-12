using Task.Integration.Data.Models.Models;
using Tasks = System.Threading.Tasks;

namespace Task.Connector.AppServices.User.Repository;

public interface IUserRepository
{
    Tasks.Task CreateAsync(UserToCreate model, CancellationToken cancellationToken);
}
