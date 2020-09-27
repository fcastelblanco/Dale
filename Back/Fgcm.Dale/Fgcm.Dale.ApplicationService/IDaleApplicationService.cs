using System.Collections.Generic;
using System.Threading.Tasks;
using Fgcm.Dale.Domain.Dtos;
using Fgcm.Dale.Domain.Entities;

namespace Fgcm.Dale.ApplicationService
{
    public interface IDaleApplicationService
    {
        Task<Product> CreateAsync(Product product);
        Product Create(Product product);
        Task<Customer> Create(Customer customer);
        Task<IEnumerable<Product>> GetAllProduct();
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<bool> Create(SaleDto saleDto);
        Task<IEnumerable<SaleDto>> GetAllSales();
    }
}