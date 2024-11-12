using Task.Integration.Data.Models.Models;
using Tasks = System.Threading.Tasks;

namespace Task.Connector.AppServices.User.Service;

public interface IUserService
{
    Tasks.Task CreateAsync(UserToCreate model, CancellationToken cancellationToken);
}
