using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using airline.management.sharedkernal.Common;
using airline.management.sharedkernal.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using airline.orders.service.Extensions;
using airline.orders.service.Persistence.Context;
using System.Linq;

namespace airline.orders.service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("====================");
            Console.WriteLine("Order Service");
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
                    if (args.Any())
                    {
                        cfg.AddJsonFile($"appsettings.{GlobalMethods.GetValueByKey(args, "environment")}.json", true, true);
                    }
                    cfg.AddEnvironmentVariables().Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddServiceConfiguration(hostContext.Configuration)
                        .AddApplicationDbContext<OrderDbContext>(hostContext.Configuration)
                        .AddEventBusService()
                        .AddServiceDependencies()
                        .AddHostedService<Worker>();
                });
    }
}
