using System.Collections.Generic;
using Polaris.Domain.Entities.Activities;
using Polaris.Domain.Entities.Organisations;

namespace Polaris.Domain.Entities.History
{
    public class TeamWorkHistory
    {
        public Team Team { get; set; }

        public IEnumerable<VotingSession> PastVotingSessions { get; set; }
    }
}