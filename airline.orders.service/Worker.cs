using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace airline.orders.service
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
            Console.WriteLine($"--> Order Service has started at: { DateTimeOffset.Now}");
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine($"--> Order Service has stopped at: { DateTimeOffset.Now}");
            await _bus.StopAsync(stoppingToken);
        }
    }
}
