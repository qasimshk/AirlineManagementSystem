using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace airline.orchestrator.service
{
    public class Worker : BackgroundService
    {        
        private readonly IBusControl _bus;

        public Worker(IBusControl bus)
        {            
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.StartAsync(stoppingToken);
            Console.WriteLine($"Orchestrator Service has started at: { DateTimeOffset.Now}");            
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine($"Orchestrator Service has stopped at: { DateTimeOffset.Now}");
            await _bus.StopAsync(stoppingToken);
        }
    }
}
