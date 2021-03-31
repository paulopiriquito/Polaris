using System;
using Polaris.Domain.Entities.Targets;
using Polaris.Domain.Entities.Users;

namespace Polaris.Domain.Entities.Votes
{
    public class UserStoryVote
    {
        public Guid UserStoryVoteId { get; set; } = Guid.NewGuid();

        public UserStory UserStory { get; set; }

        public Stakeholder VotedByStakeholder { get; set; }
    }
}