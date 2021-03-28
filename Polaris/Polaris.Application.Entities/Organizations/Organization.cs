using System;
using System.Collections.Generic;
using System.ComponentModel;
using Polaris.Application.Entities.Users;

namespace Polaris.Application.Entities.Organizations
{
    public class Organization : IEntity
    {
        public Organization(string name, User administrator)
        {
            Name = name;
            Administrator = administrator;
        }

        public Guid Id => OrganizationId;
        
        public Guid OrganizationId { get; set; } = Guid.NewGuid();

        [DisplayName("Name")]
        public string Name { get; set; }

        public IList<Team> Teams { get; set; } = new List<Team>();

        [DisplayName("Owner")]
        public User Administrator { get; set; }
    }
}