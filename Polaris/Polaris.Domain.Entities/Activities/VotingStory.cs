using System;
using Polaris.Domain.Entities.Votes;

namespace Polaris.Domain.Entities.Activities
{
    public class VotingStory
    {
        public VotingStory(UserStoryVote userStoryVote, BucketVotingResult bucketVotingResult)
        {
            UserStoryVote = userStoryVote;
            BucketVotingResult = bucketVotingResult;
        }

        public Guid VotingStoryId { get; set; } = Guid.NewGuid();

        public UserStoryVote UserStoryVote { get; set; }

        public BucketVotingResult BucketVotingResult { get; set; }
    }
}