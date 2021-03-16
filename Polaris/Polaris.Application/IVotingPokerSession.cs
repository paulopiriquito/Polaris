﻿using Polaris.Application.Entities.Targets;

namespace Polaris.Application
{
    public interface IVotingPokerSession
    {
        public void Start();
        
        public void Terminate();
        
        public UserStory? CurrentStory();

        public VotingStatus CurrentVoteStatus();

        public void CurrentStoryVote();
        
        public void NextStoryVote();
        
        public UserStory? NextStoryPeek();

        public UserStory? PreviousStoryPeek();
        
        public enum VotingStatus
        {
            Started,
            OnGoing,
            Finished,
        }
    }
}