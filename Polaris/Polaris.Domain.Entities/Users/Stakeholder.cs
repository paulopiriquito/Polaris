using Polaris.Domain.Entities.Organisations;
using Polaris.Domain.Entities.Users.Types;

namespace Polaris.Domain.Entities.Users
{
    public class Stakeholder : TeamUser
    {
        public Stakeholder(string firstName, string lastName, string email, UserType userType, Team team) : base(firstName, lastName, email, userType, team)
        {
        }
        
        private Stakeholder(TeamUser teamUser) : base(teamUser.FirstName, teamUser.LastName, teamUser.Email, teamUser.UserType, teamUser.Team)
        {
            this.UserId = teamUser.UserId;
            this.UserStories = teamUser.UserStories;
        }

        public static Stakeholder ConvertTeamUser(TeamUser teamUser)
        {
            return new Stakeholder(teamUser);
        }
        
        public static Stakeholder UpgradeAndConvert(ref User basicUser, Team team)
        {
            return new Stakeholder(Upgrade(ref basicUser, team));
        }
    }
}