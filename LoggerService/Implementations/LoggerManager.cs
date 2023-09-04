using LoggerService.Interfaces;
using LoggerService.Models;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace LoggerService.Implementations
{
    public class LoggerManager : ILoggerManager
    {
        private static Serilog.Core.Logger? _logger;

        public LoggerManager(IOptions<LoggerOptions> options) 
        {
            if (_logger == null) 
            {
                _logger = new LoggerConfiguration().WriteTo.MSSqlServer(options.Value.DatabaseConnectionString, sinkOptions: new MSSqlServerSinkOptions() { AutoCreateSqlTable = true, TableName = "Logs" }).CreateLogger();
            }
        }


        public void LogDebug(string message) => _logger?.Debug(message);
        public void LogError(string message) => _logger?.Error(message);
        public void LogInfo(string message) => _logger?.Verbose(message);
        public void LogWarn(string message) => _logger?.Warning(message);
    }
}