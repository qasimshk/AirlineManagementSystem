using airline.customers.service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace airline.customers.service.Persistence.Configurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.ToTable(nameof(Customers));

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.EmailAddress)
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(c => c.CustomerRef)
                .IsRequired();

            builder.HasIndex(c => c.EmailAddress)
                .IsUnique();

            builder.HasIndex(c => c.CorrelationId)
                .IsUnique();
        }
    }
}
