using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities.Organisations;
using Polaris.Application.Entities.Users;
using Polaris.Application.Repositories;
using Polaris.Application.Repositories.DataContexts;
using Polaris.Services.DataAccess.OnMemory.Stores;

namespace Polaris.Services.DataAccess.OnMemory.DataContexts
{
    public class OrganisationContext : OrganisationContextBase
    {
        public override ICrudRepository<Organisation> Organisations { get; } = new OrganisationStore();
    }
}