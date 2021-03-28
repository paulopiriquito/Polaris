using Polaris.Application.Entities.Organisations;
using Polaris.Application.Repositories;
using Polaris.Application.Repositories.DataContexts;
using Polaris.Services.DataAccess.OnMemory.Stores;

namespace Polaris.Services.DataAccess.OnMemory.DataContexts
{
    public class FullDataContext : IFullDataContext
    {
        public ICrudRepository<Organisation> Organisations { get; set; } = new OrganisationStore();
    }
}