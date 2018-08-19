using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.DataUploader.Entity
{
    public class User
    {
        public User()
        {
            this.UserDetails = new List<UserDetails>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }

        public virtual List<UserDetails> UserDetails { get; set; }
    }
}
