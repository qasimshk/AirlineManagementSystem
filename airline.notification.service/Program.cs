using airline.management.sharedkernal.Common;
using airline.management.sharedkernal.Extensions;
using airline.notification.service.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace airline.notification.service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("====================");
            Console.WriteLine("Notification Service");
            Console.WriteLine("====================");
            Console.WriteLine(string.Empty);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .UseWindowsService()
                .ConfigureHostConfiguration(cfg =>
                {
                    cfg.SetBasePath(Directory.GetCurrentDirectory());
                    cfg.AddJsonFile("appsettings.json", true, true);
                    cfg.AddJsonFile($"appsettings.{GlobalMethods.GetValueByKey(args, "environment")}.json", true, true);
                    cfg.AddEnvironmentVariables().Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddServiceConfiguration(hostContext.Configuration)
                        .AddEventBusService(hostContext.Configuration)
                        .AddHostedService<Worker>();
                });
    }
}
