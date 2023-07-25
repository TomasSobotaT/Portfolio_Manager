using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioManager.Data.Models;

namespace PortfolioManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Commodity>? Commodities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);
            AddTestData(builder);
        
        }

        public void AddTestData(ModelBuilder builder) 
        {
            builder.Entity<Commodity>().HasData(
                    new Commodity
                    {
                        Id = 1,
                        Name = "bitcon",
                        InvestedMoney = 100000

                    });
            
        }
    }
}