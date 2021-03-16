using System;
using Polaris.Application.Entities.Votes;

namespace Polaris.Application.Entities.Activities
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