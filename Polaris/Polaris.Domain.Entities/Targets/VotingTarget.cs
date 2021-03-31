using System;
using Polaris.Domain.Entities.Users;

namespace Polaris.Domain.Entities.Targets
{
    public abstract class VotingTarget
    {
        protected VotingTarget(string name, string detail, User creator)
        {
            Name = name;
            Detail = detail;
            Creator = creator;
        }

        public string Name { get; set; }

        public string Detail { get; set; }
        
        public User Creator { get; set; }
    }
}