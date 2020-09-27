using Fgcm.Dale.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.Data
{
    public class DaleContext : DbContext, IDaleContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public DaleContext(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringProvider.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}