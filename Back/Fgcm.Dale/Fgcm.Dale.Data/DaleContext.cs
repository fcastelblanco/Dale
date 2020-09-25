using Fgcm.Dale.Domain;
using Fgcm.Dale.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fgcm.Dale.Data
{
    public class DaleContext : DbContext, IDaleContext
    {
        public DaleContext() : base(new DbContextOptions<DaleContext>())
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Fgcm.Dale"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}