using System;
using System.Collections.Generic;
using System.Linq;
using Polaris.Application.Entities.Targets;
using Polaris.Application.Entities.Users;
using Polaris.Application.Entities.Votes;

namespace Polaris.Application.Entities.Activities
{
    public abstract class VotingSession
    {
        public VotingSession(Stakeholder stakeholder, IList<User> votingUsers, UserStoryBacklog backlogSubSet)
        {
            Stakeholder = stakeholder;
            if (votingUsers.All(x => x.UserId != stakeholder.UserId))
            {
                votingUsers.Add(stakeholder);
            }
            VotingUsers = votingUsers;
            StoriesToVote = backlogSubSet;

            CurrentStoryRef = StoriesToVote.First;
        }

        public Guid VotingSessionId { get; set; } = Guid.NewGuid();
        
        public Stakeholder Stakeholder { get; set; }

        public IList<User> VotingUsers { get; set; }

        public UserStoryBacklog StoriesToVote { get; set; }

        public IList<UserStoryVote> UserStoryVotes { get; set; } = new List<UserStoryVote>();
        
        private LinkedListNode<UserStory>? PreviousStoryRef => CurrentStoryRef?.Previous;
        
        private LinkedListNode<UserStory>? CurrentStoryRef { get; set; }
        
        private LinkedListNode<UserStory>? NextStoryRef => CurrentStoryRef?.Next;
        
        public UserStory? PreviousStoryPeek()
        {
            return PreviousStoryRef?.Value;
        }

        public UserStory? CurrentStory()
        {
            return CurrentStoryRef?.Value;
        }
        
        public UserStory? NextStoryPeek()
        {
            return NextStoryRef?.Value;
        }
        
        protected bool JumpToNextStory()
        {
            if (NextStoryRef == null) return false;
            
            CurrentStoryRef = NextStoryRef;
            return true;
        }
        
        protected bool ReturnToPreviousStory()
        {
            if (PreviousStoryRef == null) return false;
            
            CurrentStoryRef = PreviousStoryRef;
            return true;
        }
    }
}