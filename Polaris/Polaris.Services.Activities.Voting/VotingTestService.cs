using System.Collections.Generic;
using Polaris.Application.VotingPokerSession;
using Polaris.Domain.Entities.Activities;
using Polaris.Domain.Entities.Configurations;
using Polaris.Domain.Entities.Organisations;
using Polaris.Domain.Entities.Quantifiers;
using Polaris.Domain.Entities.Targets;
using Polaris.Domain.Entities.Users;
using Polaris.Domain.Entities.Users.Types;

namespace Polaris.Services.Activities.Voting
{
    public class VotingTestService
    {
        public Organisation Organisation;
        public Team Team;
        public TeamUser CurrentUser;
        public IVotingPokerSession PokerSession;
        public UserStoryBacklog Backlog;
        public UserStory StoryOne, StoryTwo;
        public BucketConfiguration UiBucketConfiguration, BackendBucketConfiguration;
        
        public VotingTestService()
        {
            var basicUser = new User("Paulo", "Piriquito", "test@mail.com", new Developer());
            Organisation = new Organisation("Cofidis", basicUser);
            Team = new Team(Organisation, basicUser);
            
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

            PokerSession = PlaningPokerSessionFactory.CreateInstance(stakeholder, new List<User>(), Backlog);
            
            //TODO Continue testing voting services
        }
    }
}