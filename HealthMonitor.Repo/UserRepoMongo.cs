using System;
using System.Collections.Generic;
using System.Text;
using HealthMonitor.Entity;
using MongoDB.Driver;
using HealthMonitor.Infrastructure;

namespace HealthMonitor.Repo
{
    public class UserRepoMongo : IUserRepoMongo
    {
        private IMongoCollection<User> _collection;

        public UserRepoMongo(IMongoConfig mongoConfig)
        {
            _collection = mongoConfig.Collection;
        }

        public void AddUser(User user) => _collection.InsertOne(user);

        public void DeleteUser(User user) => _collection.DeleteOne(u => u.Name == user.Name);

        public List<User> GetAllUsers() => _collection.Find(u => u.Id > 0).ToList();

        public User GetUser(string userName) => _collection.Find(u => u.Name == userName).FirstOrDefault();

        //public int UpdateUser(int userId, User user)
        //{
        //    _collection.UpdateOne(u)
        //}
    }
}
