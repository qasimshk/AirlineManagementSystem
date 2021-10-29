using airline.orders.service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace airline.orders.service.Persistence.Configurations
{
    public class TicketsEntityTypeConfiguration : IEntityTypeConfiguration<Tickets>
    {
        public void Configure(EntityTypeBuilder<Tickets> builder)
        {
            builder.ToTable(nameof(Tickets));

            builder.HasKey(c => c.Id);

            builder.Property(x => x.FlightNumber)
                .IsRequired();

            builder.Property(x => x.DepartureAirport)
                .IsRequired();

            builder.Property(x => x.DepartureCountry)
                .IsRequired();

            builder.Property(x => x.DepartureDate)
                .IsRequired();

            builder.Property(x => x.ArrivalAirport)
                .IsRequired();

            builder.Property(x => x.ArrivalCountry)
                .IsRequired();

            builder.Property(x => x.ArrivalDate)
                .IsRequired();

            builder.Property(x => x.FlightNumber)
                .IsRequired();

            builder.Property(x => x.CorrelationId)
                .IsRequired();

            builder.Property(x => x.OrderRef)
                .IsRequired();

            builder.Property(x => x.TicketNumber)
                .IsRequired();

            builder.HasIndex(x => x.CorrelationId)
                .IsUnique();
        }
    }
}
