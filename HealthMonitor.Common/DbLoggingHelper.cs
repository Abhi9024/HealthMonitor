using HealthMonitor.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using HealthMonitor.Infrastructure;
using MongoDB.Bson;

namespace HealthMonitor.Common.CustomErrorLogger
{
    public class DbLoggingHelper
    {
        private string connectionString;
        Random num = new Random(2);


        public DbLoggingHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertLog(EventLog log)
        {
            var command = $@"INSERT INTO [dbo].[EventLog] ([EventID],[LogLevel],[Message],[CreatedTime]) VALUES (@EventID, @LogLevel, @Message, @CreatedTime)";
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("EventID", log.EventId));
            paramList.Add(new SqlParameter("LogLevel", log.LogLevel));
            paramList.Add(new SqlParameter("Message", log.Message));
            paramList.Add(new SqlParameter("CreatedTime", log.CreatedTime));
            ExecuteNonQuery(command, paramList);
            //AddEventLog(log);
        }

        private  bool ExecuteNonQuery(string command, List<SqlParameter> paramList)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                using (SqlCommand cmd = new SqlCommand(command, conn))
                {
                    foreach (var item in paramList)
                    {
                        cmd.Parameters.Add(item);
                    }
                    
                    int count =  cmd.ExecuteNonQuery();
                    result = count > 0;
                }
            }
                return result;
        }

        private void AddEventLog(EventLog eventLog)
        {
            var client = new MongoClient(MongoConfigData.ConnectionString);
            var db = client.GetDatabase(MongoConfigData.Database);
            var errorLogger = db.GetCollection<EventLog>(MongoConfigData.ErrorLogCollection);
            eventLog.Id =  num.Next();
            errorLogger.InsertOne(eventLog);
        }
    }
}