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

        public LoggerManager(IOptions<LoggerServiceOptions> options) 
        {
            if (_logger == null) 
            {
                var configuration = new LoggerConfiguration()
                    .WriteTo.MSSqlServer(
                        options.Value.DatabaseConnectionString, 
                        sinkOptions: new MSSqlServerSinkOptions() { 
                            AutoCreateSqlTable = true, TableName = "Logs" 
                        });
                
                switch(options.Value.LogLevel)
                {
                    case Enums.LogLevel.Debug:
                        configuration = configuration.MinimumLevel.Debug();
                        break;
                    case Enums.LogLevel.Verbose: 
                        configuration = configuration.MinimumLevel.Verbose(); 
                        break;
                    default:
                        break;
                }

                _logger = configuration.CreateLogger();
            }
        }

        public void LogDebug(string message) => _logger?.Debug(message);
        public void LogError(string message, Exception? exception = null) => _logger?.Error(message, exception);
        public void LogInfo(string message) => _logger?.Information(message);
        public void LogWarn(string message) => _logger?.Warning(message);
        public void LogVerbose(string message) => _logger?.Verbose(message);
    }
}