using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.Models
{
    public class LoggerOptions
    {
        public LoggerOptions() 
        {
            DatabaseConnectionString = string.Empty;
        }

        public string DatabaseConnectionString { get; set; }
    }
}
