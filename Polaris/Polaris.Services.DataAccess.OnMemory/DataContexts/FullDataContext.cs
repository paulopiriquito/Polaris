using Polaris.Application.Entities.Organizations;
using Polaris.Application.Repositories;
using Polaris.Application.Repositories.DataContexts;
using Polaris.Services.DataAccess.OnMemory.Stores;

namespace Polaris.Services.DataAccess.OnMemory.DataContexts
{
    public class FullDataContext : IFullDataContext
    {
        public ICrudRepository<Organization> Organizations { get; set; } = new OrganizationStore();
    }
}