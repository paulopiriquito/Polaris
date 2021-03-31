using System;
using System.Collections.Generic;
using Polaris.Domain.Entities.Organisations;
using Polaris.Domain.Entities.Quantifiers;
using Polaris.Domain.Entities.Users;
using Polaris.Domain.Entities.WorkItems;

namespace Polaris.Domain.Entities.Targets
{
    public class UserStory : VotingTarget
    {
        public Guid UserStoryId { get; set; } = Guid.NewGuid();
        
        public string UserStoryReference { get; set; }
        
        public Team Team { get; set; }
        
        public IList<UserTask> UserTasks { get; set; } = new List<UserTask>();
        
        public StoryPoint? VotedStoryPoint { get; set; }

        public Priority Priority { get; set; }

        public UserStory(string name, string detail, Priority priority, User creator, Team team, string userStoryReference) : base(name, detail, creator)
        {
            Priority = priority;
            Team = team;
            UserStoryReference = userStoryReference;
        }
    }
}