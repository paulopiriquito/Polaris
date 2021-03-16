using System;
using Polaris.Application.Entities.Quantifiers;
using Polaris.Application.Entities.Targets;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Entities.Votes
{
    public class UserBucketVote
    {
        public Guid BucketVoteId { get; set; } = Guid.NewGuid();

        public Bucket Bucket { get; set; }
        
        public StepLevel VotedDifficulty { get; set; }
        
        public User VotedByUser { get; set; }
    }
}