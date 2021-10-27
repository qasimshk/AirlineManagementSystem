using airline.orchestrator.service.Persistence.Configurations;
using MassTransit.EntityFrameworkCoreIntegration;
using MassTransit.EntityFrameworkCoreIntegration.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace airline.orchestrator.service.Persistence.Context
{
    public class StateDbContext : SagaDbContext
    {
        public StateDbContext(DbContextOptions<StateDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StateDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get { yield return new StateEntityTypeConfiguration(); }
        }
    }
}
