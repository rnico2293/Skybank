using Microsoft.EntityFrameworkCore;
using Skybank.Domain.Entities;

namespace Skybank.Infrastructure.Persistence
{
    public class SkyBankDbContext : DbContext
    {
       public SkyBankDbContext(DbContextOptions<SkyBankDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure your entities here
            modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(SkyBankDbContext).Assembly); 
        }   
            public DbSet<User> Users { get; set; }  

    }
}
