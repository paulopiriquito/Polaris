using Polaris.Application.Entities.Users;

namespace Polaris.Application.Repositories.DataContexts
{
    public interface IUserContext
    {
        public ICrudRepository<User> Users { get; }

        public User? FindByEmail(string email);
    }
}