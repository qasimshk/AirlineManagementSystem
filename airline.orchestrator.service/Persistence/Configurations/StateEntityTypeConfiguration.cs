using airline.orchestrator.service.Entities;
using MassTransit.EntityFrameworkCoreIntegration.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace airline.orchestrator.service.Persistence.Configurations
{
    public class StateEntityTypeConfiguration : SagaClassMap<ServiceTransactions>
    {
        protected override void Configure(EntityTypeBuilder<ServiceTransactions> builder, ModelBuilder model)
        {
            builder.ToTable(nameof(ServiceTransactions));

            builder.Property(x => x.CurrentState).HasMaxLength(64);

            builder.Property(x => x.CustomerId).IsRequired(false);

            builder.Property(x => x.OrderId).IsRequired(false);

            builder.Property(x => x.PaymentId).IsRequired(false);

            builder.Property(x => x.TicketPrice).HasDefaultValue(0);

            builder.Property(x => x.JsonOrderRequest);

            builder.Property(x => x.CreatedOn);

            builder.Property(x => x.FailedOn).IsRequired(false);

            builder.Property(x => x.ErrorMessage).IsRequired(false);
        }
    }
}
