using Polaris.Application.Entities.Organizations;

namespace Polaris.Application.Repositories.DataContexts
{
    public interface IFullDataContext
    {
        public ICrudRepository<Organization> Organizations { get; set; }
    }
}