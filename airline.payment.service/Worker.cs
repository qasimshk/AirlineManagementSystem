using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace airline.payment.service
{
    public class Worker : BackgroundService
    {
        private readonly IBusControl _bus;
        private readonly ILogger<Worker> _logger;

        public Worker(IBusControl bus, ILogger<Worker> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.StartAsync(stoppingToken);
            _logger.LogInformation($"Payment Service has started at: {DateTimeOffset.Now}");            
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Payment Service has stopped at: {DateTimeOffset.Now}");            
            await _bus.StopAsync(stoppingToken);
        }
    }
}
