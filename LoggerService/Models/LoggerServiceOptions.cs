using LoggerService.Enums;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.Models
{
    public class LoggerServiceOptions
    {
        public LoggerServiceOptions() 
        {
            DatabaseConnectionString = string.Empty;
            LogLevel = LogLevel.Info;
        }

        public LogLevel LogLevel { get; set; }

        public string DatabaseConnectionString { get; set; }
    }
}
