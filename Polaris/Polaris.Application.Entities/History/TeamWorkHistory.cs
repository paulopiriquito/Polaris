using System.Collections.Generic;
using Polaris.Application.Entities.Activities;
using Polaris.Application.Entities.Organizations;

namespace Polaris.Application.Entities.History
{
    public class TeamWorkHistory
    {
        public Team Team { get; set; }

        public IEnumerable<VotingSession> PastVotingSessions { get; set; }
    }
}