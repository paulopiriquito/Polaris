using System;
using Polaris.Application.Entities.Quantifiers;
using Polaris.Application.Entities.Configurations;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Entities.Targets
{
    public class Bucket : VotingTarget
    {
        public static Bucket CreateInstance(BucketConfiguration configuration, UserStory userStory)
        {
            return new Bucket(configuration.Name, configuration.Detail, configuration.Creator, userStory, configuration.Weight);
        }

        private Bucket(string name, string detail, User creator, UserStory userStory, decimal weight) : base(name, detail, creator)
        {
            UserStory = userStory;
            Weight = weight;
        }

        public Guid BucketId { get; set; } = Guid.NewGuid();
        
        public decimal Weight { get; set; }
        
        public UserStory UserStory { get; set; }
    }
}