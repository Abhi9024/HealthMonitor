using HealthMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitor.Repo
{
    public interface IUserRepoEF
    {
        int AddUser(User user);
        int UpdateUser(string userName, User user);
        int DeleteUser(User user);
        User GetUser(string userName);
        List<User> GetAllUser();
    }
}
