using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitor.Entity
{
    public class UserCredential :IdentityUser
    {
        public string  UserId { get; set; }
        public string  Password { get; set; }
    }
}
