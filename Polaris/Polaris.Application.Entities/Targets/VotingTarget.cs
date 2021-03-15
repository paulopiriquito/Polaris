using System;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Entities.Targets
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