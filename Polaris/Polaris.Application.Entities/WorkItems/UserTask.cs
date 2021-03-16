using System;
using Polaris.Application.Entities.Targets;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Entities.WorkItems
{
    public class UserTask
    {
        public Guid TaskId { get; set; } = Guid.NewGuid();

        public string Title { get; set; }

        public string Detail { get; set; }

        public User User { get; set; }

        public UserStory AssociatedUserStory { get; set; }
    }
}