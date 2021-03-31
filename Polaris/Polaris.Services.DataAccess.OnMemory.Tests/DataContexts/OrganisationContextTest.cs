using Polaris.Domain.Entities.Organisations;
using Polaris.Domain.Entities.Users;
using Polaris.Domain.Entities.Users.Types;
using Polaris.Services.DataAccess.OnMemory.DataContexts;
using Shouldly;
using Xunit;

namespace Polaris.Services.DataAccess.OnMemory.Tests.DataContexts
{
    public class OrganisationContextTest
    {
        [Fact]
        public void CanGetUserOrganisations()
        {
            var context = new OrganisationContext();

            var user = new User("TestCanGetUserOrganisations", "TestCanGetUserOrganisations", "", new Developer());
            var organisation = new Organisation("TestOrg", user);
            var team = new Team(organisation, user);
            
            organisation.Teams.Add(team);
            context.Organisations.Add(organisation);
            context.Organisations.TryCommitChanges();
            
            context.UserOrganisations(user).ShouldContain(org => organisation.Id == org.Id);
        }
    }
}