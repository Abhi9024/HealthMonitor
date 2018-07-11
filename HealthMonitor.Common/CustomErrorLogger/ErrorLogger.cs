using HealthMonitor.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitor.Common.CustomErrorLogger
{
    public class ErrorLogger : ILogger
    {
        private string _categoryName;
        private Func<string, LogLevel, bool> _filter;
        private DbLoggingHelper _helper;
        private int MessageMaxLength = 4000;

        public ErrorLogger(string categoryName,Func<string,LogLevel,bool> filter,string connectionString)
        {
            _categoryName = categoryName;
            _filter = filter;
            _helper = new DbLoggingHelper(connectionString);
        }
       
        public bool IsEnabled(LogLevel logLevel)
        {
            return (_filter == null || _filter(_categoryName, logLevel));
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //Enter log details into db here.
            if (!IsEnabled(logLevel))
            {
                return;
            }
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            if (exception != null)
            {
                message += "\n" + exception.ToString();
            }

            message = (message.Length > MessageMaxLength) ? message.Substring(0, MessageMaxLength) : message;

            EventLog eventLog = new EventLog()
            {
                 EventId = eventId.Id,
                 LogLevel = logLevel.ToString(),
                 Message = message,
                 CreatedTime = DateTime.UtcNow
            };
            _helper.InsertLog(eventLog);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
