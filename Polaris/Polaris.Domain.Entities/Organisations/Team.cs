using System;
using System.Collections.Generic;
using Polaris.Domain.Entities.Activities;
using Polaris.Domain.Entities.Configurations;
using Polaris.Domain.Entities.Users;

namespace Polaris.Domain.Entities.Organisations
{
    public class Team
    {
        public Team(Organisation organisation, User owner) : this(organisation, owner, new List<BucketConfiguration>())
        {
            Members.Add(TeamUser.Upgrade(ref owner, this));
        }

        public Team(Organisation organisation, User owner, IList<BucketConfiguration> bucketConfigurations)
        {
            Organisation = organisation;
            Owner = owner;
            BucketConfigurations = bucketConfigurations;
        }

        public Guid TeamId { get; set; } = Guid.NewGuid();

        public Organisation Organisation { get; set; }

        public User Owner { get; set; }

        public IList<TeamUser> Members { get; set; } = new List<TeamUser>();

        public UserStoryBacklog Backlog { get; set; } = new UserStoryBacklog();

        public IList<BucketConfiguration> BucketConfigurations { get; set; }
    }
}