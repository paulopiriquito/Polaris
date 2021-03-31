using Microsoft.Extensions.DependencyInjection;
using Polaris.Application.VotingPokerSession;

namespace Polaris.Application
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<PlaningPokerSessionFactory>();
            return services;
        }
    }
}