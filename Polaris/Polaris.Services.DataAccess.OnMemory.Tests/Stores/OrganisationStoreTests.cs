using System;
using Polaris.Application.Entities.Organisations;
using Polaris.Application.Entities.Users;
using Polaris.Application.Entities.Users.Types;
using Polaris.Application.Repositories.DataContexts;
using Polaris.Services.DataAccess.OnMemory.DataContexts;
using Polaris.Services.DataAccess.OnMemory.Stores;
using Shouldly;
using Xunit;

namespace Polaris.Services.DataAccess.OnMemory.Tests.Stores
{
    public class OrganisationStoreTests
    {
        [Fact]
        public void CanSaveOrganisation()
        {
            var user = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            
            var org = new Organisation("Cofidis", user);
            org.ShouldNotBeNull();
            org.OrganisationId.ShouldNotBe(Guid.Empty);

            IOrganisationContext context = new OrganisationContext();
            
            context.Organisations.Add(org);
            context.Organisations.TryCommitChanges();

            context.Organisations.FindByGuid(org.Id)
                .ShouldNotBeNull()
                .Id.ShouldBe(org.Id);
        }
        
        [Fact]
        public void CanRollbackOrganisation()
        {
            var user = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            
            var org = new Organisation("Cofidis", user);
            org.ShouldNotBeNull();
            org.OrganisationId.ShouldNotBe(Guid.Empty);

            IOrganisationContext context = new OrganisationContext();
            
            context.Organisations.Add(org);
            context.Organisations.TryRollbackChanges();

            context.Organisations.FindByGuid(org.Id)
                .ShouldBeNull();
        }
    }
}