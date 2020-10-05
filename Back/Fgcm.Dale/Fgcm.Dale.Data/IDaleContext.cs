using Fgcm.Dale.Domain.Entities;
using Fgcm.Dale.Infraestructure.Definitions;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.Data
{
    public interface IDaleContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Sale> Sales { get; set; }
        DbSet<SaleDetail> SaleDetails { get; set; }
    }
}