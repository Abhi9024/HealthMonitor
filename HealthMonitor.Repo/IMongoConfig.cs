using HealthMonitor.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitor.Repo
{
    public interface IMongoConfig
    {
         MongoClient Client { get; }
         IMongoDatabase Db { get; }
         IMongoCollection<User> Collection { get; }
    }
}
