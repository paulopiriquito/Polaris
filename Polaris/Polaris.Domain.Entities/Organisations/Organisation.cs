using System;
using System.Collections.Generic;
using System.ComponentModel;
using Polaris.Domain.Entities.Users;

namespace Polaris.Domain.Entities.Organisations
{
    public class Organisation : IEntity
    {
        public Organisation(string name, User administrator)
        {
            Name = name;
            Administrator = administrator;
        }

        public Guid Id => OrganisationId;
        
        public Guid OrganisationId { get; set; } = Guid.NewGuid();

        [DisplayName("Name")]
        public string Name { get; set; }

        public IList<Team> Teams { get; set; } = new List<Team>();

        [DisplayName("Owner")]
        public User Administrator { get; set; }
    }
}