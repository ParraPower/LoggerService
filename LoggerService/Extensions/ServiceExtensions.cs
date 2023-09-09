using LoggerService.Implementations;
using LoggerService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using LoggerService.Models;

namespace LoggerService.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services, ConfigurationManager configuration)
        {
            var optionsSection = configuration.GetSection("LoggerServiceOptions");

            var options = optionsSection.Get<LoggerServiceOptions>();

            services.Configure<LoggerServiceOptions>((options) =>
            {
                options.LogLevel = options.LogLevel;
            });

            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
