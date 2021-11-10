using airline.management.domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace airline.management.infrastructure.Persistence.Context
{
    public class GatewayDbContext : IdentityDbContext
    {
        public GatewayDbContext(DbContextOptions<GatewayDbContext> options) : base(options) { }

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
