using Polaris.Application.Entities.Organizations;
using Polaris.Application.Entities.Users;
using Polaris.Application.Entities.Users.Types;
using Polaris.Services.DataAccess.OnMemory.DataContexts;
using Shouldly;
using Xunit;

namespace Polaris.Services.DataAccess.OnMemory.Tests.DataContexts
{
    public class OrganizationContextTest
    {
        [Fact]
        public void CanGetUserOrganizations()
        {
            var context = new OrganizationContext();

            var user = new User("TestCanGetUserOrganizations", "TestCanGetUserOrganizations", "", new Developer());
            var organization = new Organization("TestOrg", user);
            var team = new Team(organization, user);
            
            organization.Teams.Add(team);
            context.Organizations.Add(organization);
            context.Organizations.TryCommitChanges();
            
            context.UserOrganizations(user).ShouldContain(org => organization.Id == org.Id);
        }
    }
}