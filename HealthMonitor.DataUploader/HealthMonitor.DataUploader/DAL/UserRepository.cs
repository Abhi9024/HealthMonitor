using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMonitor.DataUploader.Entity;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.DataUploader.DAL
{
    public class UserRepository : IUserRepository
    {
        private EntityContext _context;

        public UserRepository(EntityContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            _context.Users.Add(user);
            var res = _context.SaveChanges();
            return (res > 0 ) ? true : false;

        }

        public bool DeleteUser(int id)
        {
            var usr = GetUser(id);
            foreach (var usrdtl in usr.UserDetails)
                _context.UserDetails.Remove(usrdtl);
            _context.Users.Remove(usr);
            var res = _context.SaveChanges();
            return (res > 0) ? true : false;
        }

        public List<User> GetAllUsers()
        {
           return  _context.Users.Include(u => u.UserDetails).Where(u => u.Id > 0).ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Include(u => u.UserDetails).Where(u => u.Id == id).FirstOrDefault();
        }

        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            var res = _context.SaveChanges();
            return (res > 0) ? true : false;
        }
    }
}
