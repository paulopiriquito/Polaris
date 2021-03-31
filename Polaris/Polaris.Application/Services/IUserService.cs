using System.Threading.Tasks;
using Polaris.Domain.Entities.Users;

namespace Polaris.Application.Services
{
    public interface IUserService
    {
        Task<User> GetCurrentUser();
    }
}