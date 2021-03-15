using System;
using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities.Quantifiers;
using Polaris.Application.Entities.Targets;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Entities.Votes
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