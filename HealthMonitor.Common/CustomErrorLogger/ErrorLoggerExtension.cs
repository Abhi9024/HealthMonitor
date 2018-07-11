using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitor.Common.CustomErrorLogger
{
    public static class ErrorLoggerExtension
    {
        public static ILoggerFactory AddContext(this ILoggerFactory factory, LogLevel minLevel, string connectionString)
        {
            return AddContext(factory, (_, logLevel) => (logLevel >= minLevel), connectionString);
        }

        private static ILoggerFactory AddContext(this ILoggerFactory factory, Func<string, LogLevel, bool> filter, string connectionString)
        {
            factory.AddProvider(new ErrorLogProvider(filter, connectionString));
            return factory;
        }
    }
}
