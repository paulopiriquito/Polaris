using Microsoft.Extensions.DependencyInjection;

namespace Polaris.Services.DataAccess.Database
{
    public static class Dependencies
    {
        public static IServiceCollection AddDataAccessOnMemory(this IServiceCollection services)
        {
            return services;
        }
    }
}