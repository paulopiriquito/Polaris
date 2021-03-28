using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities.Organizations;
using Polaris.Application.Entities.Users;
using Polaris.Application.Repositories;
using Polaris.Application.Repositories.DataContexts;
using Polaris.Services.DataAccess.OnMemory.Stores;

namespace Polaris.Services.DataAccess.OnMemory.DataContexts
{
    public class OrganizationContext : OrganizationContextBase
    {
        public override ICrudRepository<Organization> Organizations { get; } = new OrganizationStore();
    }
}