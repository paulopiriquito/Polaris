using System.Collections.Generic;
using Polaris.Application;
using Polaris.Application.Entities.Configurations;
using Polaris.Application.Entities.Organizations;
using Polaris.Application.Entities.Quantifiers;
using Polaris.Application.Entities.Targets;
using Polaris.Application.Entities.Users;
using Polaris.Application.Entities.Activities;
using Polaris.Application.Entities.Users.Types;

namespace Polaris.Services
{
    public class VotingTestService
    {
        public Organization Organization;
        public Team Team;
        public TeamUser CurrentUser;
        public IVotingPokerSession PokerSession;
        public UserStoryBacklog Backlog;
        public UserStory StoryOne, StoryTwo;
        public BucketConfiguration UiBucketConfiguration, BackendBucketConfiguration;
        
        public VotingTestService()
        {
            var basicUser = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            Organization = new Organization("Cofidis", basicUser);
            Team = new Team(Organization, basicUser);
            
            CurrentUser = TeamUser.Upgrade(ref basicUser, Team);
            
            UiBucketConfiguration = new BucketConfiguration("UI", "User Interface", CurrentUser);
            BackendBucketConfiguration = new BucketConfiguration("Backend", "Backend", CurrentUser, 2);
            
            Team.BucketConfigurations.Add(UiBucketConfiguration);
            Team.BucketConfigurations.Add(BackendBucketConfiguration);
            
            StoryOne = new UserStory("TestStoryOne", "TestingOne", new Priority(1), CurrentUser, Team, "25232");
            StoryTwo = new UserStory("TestStoryTwo", "TestingTwo", new Priority(2), CurrentUser, Team, "23423");
            Backlog = new UserStoryBacklog {StoryOne, StoryTwo};

            Team.Backlog = Backlog;

            var stakeholder = Stakeholder.ConvertTeamUser(CurrentUser);

            PokerSession = new PlaningPokerSession(stakeholder, new List<User>(), Backlog);
            
            //TODO Continue testing voting services
        }
    }
}