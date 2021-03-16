using System;
using Polaris.Application.Entities.Targets;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Entities.Votes
{
    public class UserStoryVote
    {
        public Guid UserStoryVoteId { get; set; } = Guid.NewGuid();

        public UserStory UserStory { get; set; }

        public Stakeholder VotedByStakeholder { get; set; }
    }
}