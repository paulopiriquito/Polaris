using System;
using Polaris.Domain.Entities.Users;

namespace Polaris.Domain.Entities.Configurations
{
    public class BucketConfiguration
    {
        public BucketConfiguration(string name, string detail, User creator, decimal weight = decimal.One)
        {
            Name = name;
            Detail = detail;
            Creator = creator;
            Weight = weight;
        }

        public Guid BucketConfigurationId { get; set; } = Guid.NewGuid();
        
        public string Name { get; set; }

        public string Detail { get; set; }
        
        public User Creator { get; set; }
        
        public decimal Weight { get; set; }
    }
}