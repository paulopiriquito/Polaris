using System;
using System.Collections.Generic;
using System.Linq;
using Polaris.Domain.Entities.Quantifiers;
using Polaris.Domain.Entities.Targets;
using Polaris.Domain.Entities.Users;

namespace Polaris.Domain.Entities.Votes
{
    public class UserBucketVotingResult
    {
        public Guid UserBucketVotingResultId { get; set; } = Guid.NewGuid();

        public User User { get; set; }

        public IList<UserBucketVote> BucketVotes { get; set; } = new List<UserBucketVote>();

        public IEnumerable<Bucket> VotedBuckets => BucketVotes.Select(x => x.Bucket).Distinct();
        
        public StoryPoint? UserStoryPointOverride { get; set; }
    }
}