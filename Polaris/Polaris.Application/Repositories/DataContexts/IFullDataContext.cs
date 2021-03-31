using Polaris.Domain.Entities.Organisations;

namespace Polaris.Application.Repositories.DataContexts
{
    public interface IFullDataContext
    {
        public ICrudRepository<Organisation> Organisations { get; set; }
    }
}