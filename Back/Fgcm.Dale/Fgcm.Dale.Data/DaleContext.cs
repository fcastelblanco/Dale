using System.Linq;
using Fgcm.Dale.Domain.Entities;
using Fgcm.Dale.Infraestructure.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.Data
{
    public class DaleContext : DbContext, IDaleContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringProvider.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DaleContext(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }  
        public DbSet<SaleDetail> SaleDetails { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();

            return base.SaveChanges();
        }
    }
}