using System.Collections.Generic;
using Polaris.Domain.Entities.Activities;
using Polaris.Domain.Entities.Users;

namespace Polaris.Application.VotingPokerSession
{
    public class PlaningPokerSessionFactory
    {
        public static IVotingPokerSession CreateInstance(Stakeholder stakeholder, IList<User> votingUsers, UserStoryBacklog backlogSubSet)
        {
            return new PlaningPokerSession(stakeholder, votingUsers, backlogSubSet);
        }
    }
}