using System.Collections.Generic;
using System.Linq;
using Polaris.Domain.Entities.Activities;
using Polaris.Domain.Entities.Users;
using Polaris.Domain.Entities.Votes;
using Polaris.Domain.Entities.WorkFlow;

namespace Polaris.Application.VotingPokerSession
{
    internal class PlaningPokerSession : VotingSession , IVotingPokerSession
    {
        internal PlaningPokerSession(Stakeholder stakeholder, IList<User> votingUsers, UserStoryBacklog backlogSubSet) : base(stakeholder, votingUsers, backlogSubSet)
        {
            _tracker = new VotingTracker(votingUsers);
            TeamBucketVotes = new List<UserBucketVotingResult>(backlogSubSet.TotalUserStories);
        }

        private bool HasStarted { get; set; }
        private bool HasTerminated { get; set; }

        private readonly VotingTracker _tracker;

        private IList<UserBucketVotingResult> TeamBucketVotes { get; set; }
        
        public void Start()
        {
            
        }

        public void Terminate()
        {
            throw new System.NotImplementedException();
        }

        public IVotingPokerSession.VotingStatus CurrentVoteStatus()
        {
            var startingCount = _tracker.StaringUsers.Count;
            var remainingCount = _tracker.RemainingUsersToVote.Count();

            if (startingCount == remainingCount)
                return IVotingPokerSession.VotingStatus.Started;

            return remainingCount == 0 ? IVotingPokerSession.VotingStatus.Finished : IVotingPokerSession.VotingStatus.OnGoing;
        }

        public void CurrentStoryVote()
        {
            throw new System.NotImplementedException();
        }

        public void NextStoryVote()
        {
            if (JumpToNextStory())
            {
                _tracker.Reset(VotingUsers);
                _tracker.CurrentTargetId = CurrentStory()?.UserStoryId;
            }
            else
            {
                Terminate();
            }
        }
    }
}