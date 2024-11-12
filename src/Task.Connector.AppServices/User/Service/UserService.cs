using Task.Connector.AppServices.User.Repository;
using Task.Integration.Data.Models;
using Task.Integration.Data.Models.Models;
using Tasks = System.Threading.Tasks;

namespace Task.Connector.AppServices.User.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger _logger;

    public UserService(IUserRepository userRepository, ILogger logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Tasks.Task CreateAsync(UserToCreate model, CancellationToken cancellationToken)
    {
        await _userRepository.CreateAsync(model, cancellationToken);
    }
}
