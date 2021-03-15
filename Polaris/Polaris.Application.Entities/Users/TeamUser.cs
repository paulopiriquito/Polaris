using System;
using Polaris.Application.Entities.Organizations;

namespace Polaris.Application.Entities.Users
{
    public class TeamUser : User
    {
        public TeamUser(string firstName, string lastName, string email, UserType userType, Team team) : base(firstName, lastName, email, userType)
        {
            Team = team;
        }
        
        private TeamUser(User toUpgrade, Team team) : base(toUpgrade.FirstName, toUpgrade.LastName, toUpgrade.Email, toUpgrade.UserType)
        {
            this.UserId = toUpgrade.UserId;
            this.UserStories = toUpgrade.UserStories;
            Team = team;
        }
        
        public Team Team { get; set; }

        public static TeamUser Upgrade(ref User user, Team team)
        {
            user = new TeamUser(user, team);
            return  user as TeamUser ?? throw new InvalidOperationException();
        }
    }
}