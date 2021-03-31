using Polaris.Application.Repositories;
using Polaris.Domain.Entities.Organisations;
using Polaris.Services.DataAccess.OnMemory.Stores;

namespace Polaris.Services.DataAccess.OnMemory.DataContexts
{
    internal class OrganisationContext : OrganisationContextBase
    {
        public override ICrudRepository<Organisation> Organisations { get; } = new OrganisationStore();
    }
}