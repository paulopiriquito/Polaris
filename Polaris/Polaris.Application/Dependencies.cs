using Microsoft.Extensions.DependencyInjection;

namespace Polaris.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}