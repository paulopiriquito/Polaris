using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities.Activities;
using Polaris.Application.Entities.Users;
using Polaris.Application.Entities.Votes;
using Polaris.Application.Entities.WorkFlow;

namespace Polaris.Application
{
    public class PlaningPokerSession : VotingSession , IVotingPokerSession
    {
        public PlaningPokerSession(Stakeholder stakeholder, IList<User> votingUsers, UserStoryBacklog backlogSubSet) : base(stakeholder, votingUsers, backlogSubSet)
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