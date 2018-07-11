using HealthMonitor.Infrastructure.Enums;
using System;
using System.Collections.Generic;

namespace HealthMonitor.Entity
{
    public class User
    {
        //public User()
        //{
        //    this.UserHealthTracker = new List<UserHealthTracker>();
        //}
        public int Id { get; set; }
        public string  Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }

        public IList<UserHealthTracker> UserHealthTracker { get; set; }
        //to be added as the need arises
    }
}
