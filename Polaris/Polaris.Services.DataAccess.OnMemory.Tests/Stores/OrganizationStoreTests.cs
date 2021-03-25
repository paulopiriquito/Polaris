using System;
using Polaris.Application.Entities.Organizations;
using Polaris.Application.Entities.Users;
using Polaris.Application.Entities.Users.Types;
using Polaris.Application.Repositories.DataContexts;
using Polaris.Services.DataAccess.OnMemory.DataContexts;
using Polaris.Services.DataAccess.OnMemory.Stores;
using Shouldly;
using Xunit;

namespace Polaris.Services.DataAccess.OnMemory.Tests.Stores
{
    public class OrganizationStoreTests
    {
        [Fact]
        public void CanSaveOrganization()
        {
            var user = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            
            var org = new Organization("Cofidis", user);
            org.ShouldNotBeNull();
            org.OrganizationId.ShouldNotBe(Guid.Empty);

            IOrganizationContext context = new OrganizationContext();
            
            context.Organizations.Add(org);
            context.Organizations.TryCommitChanges();

            context.Organizations.FindByGuid(org.Id)
                .ShouldNotBeNull()
                .Id.ShouldBe(org.Id);
        }
        
        [Fact]
        public void CanRollbackOrganization()
        {
            var user = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            
            var org = new Organization("Cofidis", user);
            org.ShouldNotBeNull();
            org.OrganizationId.ShouldNotBe(Guid.Empty);

            IOrganizationContext context = new OrganizationContext();
            
            context.Organizations.Add(org);
            context.Organizations.TryRollbackChanges();

            context.Organizations.FindByGuid(org.Id)
                .ShouldBeNull();
        }
    }
}