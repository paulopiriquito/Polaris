using System.Collections.Generic;
using Polaris.Application.Entities.Organizations;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Repositories.DataContexts
{
    public interface IOrganizationContext
    {
        public ICrudRepository<Organization> Organizations { get; }

        public IEnumerable<Organization> UserOrganizations(User user);
    }
}