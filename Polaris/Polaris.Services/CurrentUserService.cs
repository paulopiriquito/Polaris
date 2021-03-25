using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities.Users;
using Polaris.Application.Services;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Polaris.Application.Entities.Users.Types;

namespace Polaris.Services
{ 
    public class CurrentUserService : IUserService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public CurrentUserService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }
        
        public async Task<User> GetCurrentUser()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                return new User(
                    user.FindFirst(c => c.Type == ClaimTypes.GivenName)?.Value ?? string.Empty,
                    user.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value ?? string.Empty,
                    user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty, 
                    new Tester());
            }
            return null;
        }
    }
}