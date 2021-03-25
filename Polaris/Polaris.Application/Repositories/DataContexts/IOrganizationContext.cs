using Polaris.Application.Entities.Organizations;

namespace Polaris.Application.Repositories.DataContexts
{
    public interface IOrganizationContext
    {
        public ICrudRepository<Organization> Organizations { get; set; }
    }
}