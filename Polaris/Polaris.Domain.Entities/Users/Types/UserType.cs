using System;

namespace Polaris.Domain.Entities.Users.Types
{
    public abstract class UserType
    {
        public Guid UserTypeId { get; set; } = Guid.NewGuid();

        public string Name { get; protected set; }

        public string Description { get; protected set; }
    }
}