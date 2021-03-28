using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities.Organisations;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Repositories.DataContexts
{
    public abstract class OrganisationContextBase : IOrganisationContext
    {
        public abstract ICrudRepository<Organisation> Organisations { get; }

        public IEnumerable<Organisation> UserOrganisations(User user)
        {
            var teams = Organisations
                .Where(
                    organisation => 
                        organisation.Administrator.UserId == user.UserId ||
                        organisation.Teams.Any(team => team.Members.Any(member => member.UserId == user.UserId) || team.Owner.UserId == user.UserId)
                );
            return teams;
        }
    }
}