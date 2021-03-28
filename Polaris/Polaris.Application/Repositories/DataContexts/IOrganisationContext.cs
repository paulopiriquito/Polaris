using System.Collections.Generic;
using Polaris.Application.Entities.Organisations;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Repositories.DataContexts
{
    public interface IOrganisationContext
    {
        public ICrudRepository<Organisation> Organisations { get; }

        public IEnumerable<Organisation> UserOrganisations(User user);
    }
}