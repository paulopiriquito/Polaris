using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities.Users;
using Polaris.Application.Services;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Polaris.Application.Entities.Users.Types;
using Polaris.Application.Repositories.DataContexts;

namespace Polaris.Services
{ 
    public class CurrentUserService : IUserService
    {
        private readonly IUserContext _userContext;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public CurrentUserService(AuthenticationStateProvider authenticationStateProvider, IUserContext userContext)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _userContext = userContext;
        }
        
        public async Task<User> GetCurrentUser()
        {
            var userCandidate = await FindAndRegisterCandidateFromLoginMetadata();

            return userCandidate;
        }

        private async Task<User> FindAndRegisterCandidateFromLoginMetadata()
        {
            var userMetadata = await GetAuthenticatedMetadata();

            if (userMetadata == null) return null;

            var loggedEmailAddress = userMetadata.FindFirst(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty;
            
            if (string.IsNullOrEmpty(loggedEmailAddress)) return null;
            
            var candidate = _userContext.FindByEmail(loggedEmailAddress);

            if (candidate != null) return candidate;
                    
            candidate = new User(
                userMetadata.FindFirst(c => c.Type == ClaimTypes.GivenName)?.Value ?? string.Empty,
                userMetadata.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value ?? string.Empty,
                userMetadata.FindFirst(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty, 
                new Tester());
            
            _userContext.Users.Add(candidate);
            _userContext.Users.TryCommitChanges();

            return candidate;
        }

        private async Task<ClaimsPrincipal> GetAuthenticatedMetadata()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity == null || !user.Identity.IsAuthenticated) return null;

            return user;
        }
    }
}