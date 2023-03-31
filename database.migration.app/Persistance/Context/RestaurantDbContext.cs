using airline.payment.service.Persistence.Context;
using database.migration.app.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace database.migration.app.Persistance.Context
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

        public DbSet<Menu> Menus { get; set; } = null!;

        // dotnet ef migrations add Initial --output-dir "Persistance/Migrations"

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentDbContext).Assembly);

            modelBuilder.HasSequence<int>("GeneratedStringSequence")
                .StartsAt(10000)
                .IncrementsBy(1);

            base.OnModelCreating(modelBuilder);
        }
    }
}
