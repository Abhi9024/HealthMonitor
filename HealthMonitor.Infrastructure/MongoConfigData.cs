using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HealthMonitor.Infrastructure
{
    public static class MongoConfigData
    {
        private static MongoConfig _configData;

        static MongoConfigData()
        {
            using (StreamReader sr = new StreamReader("MongoConfig.json"))
            {
                var config = sr.ReadToEnd();
                _configData = JsonConvert.DeserializeObject<MongoConfig>(config);
            }
        }

        public static string ConnectionString => _configData.ConnectionString;

        public static string Database => _configData.Database;

        public static string Collection => _configData.Collection;

        public static string ErrorLogCollection => _configData.ErrorLogCollection;
    }

    internal class MongoConfig
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
        public string ErrorLogCollection { get; set; }
    }
}
