using System;
using Polaris.Domain.Entities.Targets;
using Polaris.Domain.Entities.Users;

namespace Polaris.Domain.Entities.WorkItems
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