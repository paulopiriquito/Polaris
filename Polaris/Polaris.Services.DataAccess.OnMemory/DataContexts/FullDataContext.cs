using Polaris.Application.Repositories;
using Polaris.Application.Repositories.DataContexts;
using Polaris.Domain.Entities.Organisations;
using Polaris.Services.DataAccess.OnMemory.Stores;

namespace Polaris.Services.DataAccess.OnMemory.DataContexts
{
    public class FullDataContext : IFullDataContext
    {
        public ICrudRepository<Organisation> Organisations { get; set; } = new OrganisationStore();
    }
}