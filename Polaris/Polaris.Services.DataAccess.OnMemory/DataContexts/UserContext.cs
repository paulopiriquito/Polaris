using Polaris.Application.Entities.Users;
using Polaris.Application.Repositories;
using Polaris.Application.Repositories.DataContexts;
using Polaris.Services.DataAccess.OnMemory.Stores;

namespace Polaris.Services.DataAccess.OnMemory.DataContexts
{
    public class UserContext : IUserContext
    {
        public ICrudRepository<User> Users { get; } = new UserStore();
        
        public User? FindByEmail(string email)
        {
            return Users.FirstOrDefault(x => x.Email == email);
        }
    }
}