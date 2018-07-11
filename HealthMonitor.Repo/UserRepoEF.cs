using System;
using System.Collections.Generic;
using HealthMonitor.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.Repo
{
    public class UserRepoEF:IUserRepoEF
    {
        private UserContext _context;

        public UserRepoEF(UserContext context)
        {
           this._context = context;
        }

        public int AddUser(User user) => Convert.ToInt32(_context.User.Add(user));

        public int DeleteUser(User user) => Convert.ToInt32(_context.User.Remove(user));

        public List<User> GetAllUser() => _context.User.Where(u => u.Id > 0).ToList();

        public User GetUser(string userName) => _context.User.Include(u => u.UserHealthTracker).Where(u=>u.Name == userName).FirstOrDefault();

        public int UpdateUser(string userName, User user)
        {
            var result = 0;
            var data = _context.User.Find(userName);
            if (data.Id == user.Id)
                result = Convert.ToInt32(_context.User.Update(user));

            return result;
        }
    }
}
