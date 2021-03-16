using System;
using System.Collections.Generic;
using System.Security.Claims;
using Polaris.Application.Entities.Targets;

namespace Polaris.Application.Entities.Users
{
    public class User
    {
        public User(string firstName, string lastName, string email, UserType userType)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserType = userType;
        }

        public Guid UserId { get; set; } = Guid.NewGuid();
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Fullname => $"{FirstName} {LastName}";
        
        public string Email { get; set; }
        public UserType UserType { get; set; }

        public IEnumerable<UserStory> UserStories { get; set; } = new List<UserStory>();
    }
}