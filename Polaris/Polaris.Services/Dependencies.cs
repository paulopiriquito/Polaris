using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Polaris.Application.Services;

namespace Polaris.Services
{
    public static class Dependencies
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService>(provider => new CurrentUserService(provider.GetService<AuthenticationStateProvider>()));
            return services;
        }
    }
}