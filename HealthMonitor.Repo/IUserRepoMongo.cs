using HealthMonitor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitor.Repo
{
    public interface IUserRepoMongo
    {
        void AddUser(User user);
        //void UpdateUser(int userId, User user);
        void DeleteUser(User user);
        User GetUser(string userName);
        List<User> GetAllUsers();
    }
}
