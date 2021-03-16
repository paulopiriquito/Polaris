using System;
using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities.Quantifiers;
using Polaris.Application.Entities.Targets;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Entities.Votes
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