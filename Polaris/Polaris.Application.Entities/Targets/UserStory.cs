using System;
using System.Collections.Generic;
using Polaris.Application.Entities.Organizations;
using Polaris.Application.Entities.Quantifiers;
using Polaris.Application.Entities.Users;
using Polaris.Application.Entities.WorkItems;

namespace Polaris.Application.Entities.Targets
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