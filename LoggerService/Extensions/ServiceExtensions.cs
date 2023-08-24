using LoggerService.Implementations;
using LoggerService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LoggerService.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
