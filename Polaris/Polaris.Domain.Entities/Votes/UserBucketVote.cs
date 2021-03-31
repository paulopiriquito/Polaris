using System;
using Polaris.Domain.Entities.Quantifiers;
using Polaris.Domain.Entities.Targets;
using Polaris.Domain.Entities.Users;

namespace Polaris.Domain.Entities.Votes
{
    public class UserBucketVote
    {
        public Guid BucketVoteId { get; set; } = Guid.NewGuid();

        public Bucket Bucket { get; set; }
        
        public StepLevel VotedDifficulty { get; set; }
        
        public User VotedByUser { get; set; }
    }
}