using airline.customers.service.Consumers;
using airline.customers.service.Entities;
using airline.customers.service.Persistence.Repositories.Abstractions;
using airline.management.abstractions.Customers;
using airline.management.domain.Events;
using airline.management.infrastructure.test.Seeds;
using FluentAssertions;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace airline.customer.service.test.Consumers
{
    public class CustomerDetailsConsumerTests
    {   
        private readonly ICustomerRepository _customerRepository;

        public CustomerDetailsConsumerTests()
        {        
            _customerRepository = Substitute.For<ICustomerRepository>();
        }

        [Fact]
        public async Task CustomerDetailsConsumer_ShouldReturnCustomerDetails_ReturnSuccessful()
        {
            // Arrange
            var customer = GetTestData.GetMockCustomerDetailEvent();

            var provider = new ServiceCollection()
            .AddMassTransitInMemoryTestHarness(cfg =>
            {
                cfg.AddConsumer<CustomerDetailsConsumer>();
                cfg.AddConsumerTestHarness<CustomerDetailsConsumer>();
            })
            .AddScoped(x => _customerRepository)
            .BuildServiceProvider(true);

            _customerRepository.FindByConditionAsync(Arg.Any<Expression<Func<Customers, bool>>>()).Returns(customer);

            var harness = provider.GetRequiredService<InMemoryTestHarness>();

            await harness.Start();
            try
            {
                // Act
                var bus = provider.GetRequiredService<IBus>();

                var client = bus.CreateRequestClient<ICustomerDetailRequest>();

                var response = await client.GetResponse<ICustomerDetailsResult>(new CustomerDetailRequest
                {
                    CustomerReferrence = customer.Single().CorrelationId
                });

                var result = await harness.Consumed.Any<ICustomerDetailRequest>();

                // Assert
                result.Should().BeTrue();

                var consumerHarness = provider.GetRequiredService<IConsumerTestHarness<CustomerDetailsConsumer>>();

                (await consumerHarness.Consumed.Any<ICustomerDetailRequest>()).Should().BeTrue();

                response.Message.FirstName.Should().BeEquivalentTo(customer.Single().FirstName);
            }
            finally
            {
                await harness.Stop();

                await provider.DisposeAsync();
            }
        }
    }
}
