using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities.Organizations;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Repositories.DataContexts
{
    public abstract class OrganizationContextBase : IOrganizationContext
    {
        public abstract ICrudRepository<Organization> Organizations { get; }

        public IEnumerable<Organization> UserOrganizations(User user)
        {
            var teams = Organizations
                .Where(
                    organization => 
                        organization.Administrator.UserId == user.UserId ||
                        organization.Teams.Any(team => team.Members.Any(member => member.UserId == user.UserId) || team.Owner.UserId == user.UserId)
                );
            return teams;
        }
    }
}