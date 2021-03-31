using System;
using System.Collections.Generic;
using System.Linq;
using Polaris.Domain.Entities.Quantifiers;
using Polaris.Domain.Entities.Targets;
using Polaris.Domain.Entities.Users;

namespace Polaris.Domain.Entities.Votes
{
    public class BucketVotingResult
    {
        public Guid BucketVotingResultId { get; set; } = Guid.NewGuid();

        public IEnumerable<UserBucketVotingResult> UserBucketVotingResults { get; set; } = new UserBucketVotingResult[0];

        private IEnumerable<Bucket> VotedBuckets => UserBucketVotingResults
            .SelectMany(votingResult => votingResult.VotedBuckets)
            .Distinct();

        private IEnumerable<User> VotingUsers => UserBucketVotingResults
            .Select(votingResult => votingResult.User);

        public StoryPoint RecommendStoryPoint()
        {
            throw new NotImplementedException();
        }
    }
}