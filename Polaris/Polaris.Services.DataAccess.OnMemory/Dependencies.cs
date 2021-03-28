using Microsoft.Extensions.DependencyInjection;
using Polaris.Application.Repositories.DataContexts;
using Polaris.Services.DataAccess.OnMemory.DataContexts;

namespace Polaris.Services.DataAccess.OnMemory
{
    public static class Dependencies
    {
        public static IServiceCollection AddDataAccessOnMemory(this IServiceCollection services)
        {
            services.AddScoped<IFullDataContext>(provider => new FullDataContext());
            services.AddScoped<IOrganisationContext>(provider => new OrganisationContext());
            services.AddScoped<IUserContext>(provider => new UserContext());
            return services;
        }
    }
}