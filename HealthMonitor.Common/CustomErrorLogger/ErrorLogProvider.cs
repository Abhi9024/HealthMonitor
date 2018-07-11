using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitor.Common.CustomErrorLogger
{
    public class ErrorLogProvider : ILoggerProvider
    {
        private Func<string, LogLevel, bool> _filter;
        private string _connectionString;

        public ErrorLogProvider(Func<string,LogLevel,bool> filter, string connectionString)
        {
            _filter = filter;
            _connectionString = connectionString;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ErrorLogger(categoryName, _filter, _connectionString);
        }

        public void Dispose()
        {
            
        }
    }
}
