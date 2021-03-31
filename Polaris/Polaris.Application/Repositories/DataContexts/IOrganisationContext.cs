using System.Collections.Generic;
using Polaris.Domain.Entities.Organisations;
using Polaris.Domain.Entities.Users;

namespace Polaris.Application.Repositories.DataContexts
{
    public interface IOrganisationContext
    {
        public ICrudRepository<Organisation> Organisations { get; }

        public IEnumerable<Organisation> UserOrganisations(User user);
    }
}