using airline.payment.service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace airline.payment.service.Persistence.Configurations
{
    public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.ToTable(nameof(Transactions));

            builder.HasKey(c => c.Id);

            builder.Property(x => x.TransactionRef)
                .IsRequired();

            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.CorrelationId)
                .IsRequired();

            builder.HasIndex(x => x.CorrelationId)
                .IsUnique();
        }
    }
}
