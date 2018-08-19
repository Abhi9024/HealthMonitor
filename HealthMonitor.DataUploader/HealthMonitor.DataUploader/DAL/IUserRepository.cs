using HealthMonitor.DataUploader.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.DataUploader.DAL
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        bool UpdateUser(User user);
        bool AddUser(User user);
        bool DeleteUser(int id);
    }
}
