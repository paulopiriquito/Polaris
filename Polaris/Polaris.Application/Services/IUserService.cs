using System.Threading.Tasks;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Services
{
    public interface IUserService
    {
        Task<User> GetCurrentUser();
    }
}