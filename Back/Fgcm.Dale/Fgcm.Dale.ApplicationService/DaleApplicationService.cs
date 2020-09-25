using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fgcm.Dale.Domain.Dtos;
using Fgcm.Dale.Domain.Entities;
using Fgcm.Dale.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.ApplicationService
{
    public class DaleApplicationService : IDaleApplicationService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleDetailRepository _saleDetailRepository;

        public DaleApplicationService(IProductRepository productRepository, ICustomerRepository customerRepository, ISaleRepository saleRepository, ISaleDetailRepository saleDetailRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _saleRepository = saleRepository;
            _saleDetailRepository = saleDetailRepository;
        }

        public async Task<Product> Create(Product product)
        {
            await _productRepository.Insert(product);
            return product;
        }

        public async Task<Customer> Create(Customer customer)
        {
            await _customerRepository.Insert(customer);
            return customer;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _productRepository.GetAll().ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await _customerRepository.GetAll().ToListAsync();
        }

        public async Task<bool> Create(SaleDto saleDto)
        {
            var sale = new Sale
            {
                CustomerId = saleDto.CustomerId,
                Total = saleDto.Total
            };

            await _saleRepository.Insert(sale);

            foreach (var saleDtoSaleDetailDto in saleDto.SaleDetailDtos)
            {
                await _saleDetailRepository.Insert(new SaleDetail
                {
                    SaleId = sale.Id,
                    ProductId = saleDtoSaleDetailDto.ProductId,
                    Quantity = saleDtoSaleDetailDto.Quantity
                });
            }

            return true;
        }

        public async Task<IEnumerable<SaleDto>> GetAllSales()
        {
            var dataToReturn = new List<SaleDto>();
            var allSales = await _saleRepository.GetAll().ToListAsync();

            foreach (var allSale in allSales)
            {
                var saleDetails = await _saleDetailRepository.FindBy(x => x.SaleId == allSale.Id).ToListAsync();

                dataToReturn.Add(new SaleDto
                {
                    CustomerId = allSale.CustomerId,
                    Total = allSale.Total,
                    SaleDetailDtos = saleDetails.Select( x => new SaleDetailDto
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity
                    })
                });
            }

            return dataToReturn;
        }
    }
}