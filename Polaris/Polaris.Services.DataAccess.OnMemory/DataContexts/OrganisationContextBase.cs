using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Repositories;
using Polaris.Application.Repositories.DataContexts;
using Polaris.Domain.Entities.Organisations;
using Polaris.Domain.Entities.Users;

namespace Polaris.Services.DataAccess.OnMemory.DataContexts
{
    internal abstract class OrganisationContextBase : IOrganisationContext
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