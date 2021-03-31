using System;
using System.Collections.Generic;
using System.Linq;
using Polaris.Domain.Entities.Users;

namespace Polaris.Domain.Entities.WorkFlow
{
    public class VotingTracker
    {
        public VotingTracker(IList<User> startingUsers)
        {
            StaringUsers = startingUsers;
        }

        public Guid VotingTrackerId { get; set; } = Guid.NewGuid();
        
        public Guid? CurrentTargetId { get; set; } = Guid.NewGuid();

        public IEnumerable<User> RemainingUsersToVote => StaringUsers.Where(x=> UsersThatVoted.Contains(x));
        
        public IList<User> StaringUsers { get; set; }

        public IList<User> UsersThatVoted { get; set; } = new List<User>();
        
        public IEnumerable<User> UpdateUserHasVoted(User user)
        {
            UsersThatVoted.Add(StaringUsers.First(x => x.UserId == user.UserId));
            return RemainingUsersToVote;
        }
        
        public IEnumerable<User> UpdateUserJoined(User user)
        {
            StaringUsers.Add(user);
            return RemainingUsersToVote;
        }

        public void Reset()
        {
            UsersThatVoted = new List<User>();
        }
        
        public void Reset(IList<User> currentUsers)
        {
            StaringUsers = currentUsers;
            Reset();
        }
    }
}