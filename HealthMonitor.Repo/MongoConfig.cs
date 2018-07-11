using System;
using System.Collections.Generic;
using System.Text;
using HealthMonitor.Entity;
using MongoDB.Driver;
using HealthMonitor.Infrastructure;

namespace HealthMonitor.Repo
{
    public class MongoConfig : IMongoConfig
    {
        public MongoClient Client => new MongoClient(MongoConfigData.ConnectionString);
        public IMongoDatabase Db => Client.GetDatabase(MongoConfigData.Database);
        public IMongoCollection<User> Collection => Db.GetCollection<User>(MongoConfigData.Collection);
    }
}
