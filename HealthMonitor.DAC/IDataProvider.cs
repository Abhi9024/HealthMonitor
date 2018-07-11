using HealthMonitor.Entity;
using System.Collections.Generic;

namespace HealthMonitor.DAC
{
    public interface IDataProvider
    {
        List<User> GetAllUsers();
        User GetUser(string name);
    }
}