using System;
using System.Collections.Generic;
using Polaris.Domain.Entities.Configurations;
using Polaris.Domain.Entities.Organisations;
using Polaris.Domain.Entities.Quantifiers;
using Polaris.Domain.Entities.Targets;
using Polaris.Domain.Entities.Users;
using Polaris.Domain.Entities.Users.Types;
using Shouldly;
using Xunit;

namespace Polaris.Application.Tests
{
    public class BasicFeatureTests
    {
        [Fact]
        public void CanCreateUser()
        {
            var user = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            user.ShouldNotBeNull();
            user.UserStories.ShouldNotBeNull();
            user.UserId.ShouldNotBe(Guid.Empty);
        }
        
        [Fact]
        public void CanCreateOrganisation()
        {
            var user = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            
            var org = new Organisation("Cofidis", user);
            org.ShouldNotBeNull();
            org.OrganisationId.ShouldNotBe(Guid.Empty);
        }
        
        [Fact]
        public void CanCreateTeam()
        {
            var user = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            var org = new Organisation("Cofidis", user);
            
            var team = new Team(org, user);
            team.ShouldNotBeNull();
            team.TeamId.ShouldNotBe(Guid.Empty);
        }
        
        [Fact]
        public void CanCreateUserStory()
        {
            var user = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            var org = new Organisation("Cofidis", user);
            var team = new Team(org, user);

            var story = new UserStory("TestStory", "Testing", new Priority(1), user, team, "1");
            story.ShouldNotBeNull();
            story.Priority.Value.ShouldBe(1);
            story.UserStoryId.ShouldNotBe(Guid.Empty);
        }
        
        [Fact]
        public void CanCreateBuckets()
        {
            var user = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            var org = new Organisation("Cofidis", user);
            
            var bucketConfiguration = new BucketConfiguration("TestBucket", "Testing", user);
            bucketConfiguration.BucketConfigurationId.ShouldNotBe(Guid.Empty);
            
            var team = new Team(org, user, new List<BucketConfiguration>(){bucketConfiguration});
            var story = new UserStory("TestStory", "Testing", new Priority(1), user, team, "1");

            var bucket = Bucket.CreateInstance(team.BucketConfigurations[0], story);
            bucket.ShouldNotBeNull();
            bucket.BucketId.ShouldNotBe(Guid.Empty);
            bucket.Name.ShouldBe(bucketConfiguration.Name);
            bucket.Detail.ShouldBe(bucketConfiguration.Detail);
            bucket.Weight.ShouldBe(bucketConfiguration.Weight);
        }
        
        [Fact]
        public void CanCreateVotingSession()
        {
            
        }
        
        [Fact]
        public void CanVote()
        {
            
        }
        
        [Fact]
        public void CanCalculateSuggestedPoints()
        {
            
        }
    }
}