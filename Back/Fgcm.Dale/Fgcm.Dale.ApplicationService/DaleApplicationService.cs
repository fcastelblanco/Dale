using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Fgcm.Dale.Domain.Dtos;
using Fgcm.Dale.Domain.Entities;
using Fgcm.Dale.Infraestructure;
using Fgcm.Dale.Repository.Definitions.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Fgcm.Dale.ApplicationService
{
    public class DaleApplicationService : IDaleApplicationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISaleDetailRepository _saleDetailRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DaleApplicationService(IProductRepository productRepository, ICustomerRepository customerRepository,
            ISaleRepository saleRepository, ISaleDetailRepository saleDetailRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _saleRepository = saleRepository;
            _saleDetailRepository = saleDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            try
            {
                _productRepository.Create(product);
                await _unitOfWork.CommitAsync();
                return product;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public Product Create(Product product)
        {
            try
            {
                _productRepository.Create(product);
                _unitOfWork.Commit();
                return product;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }

        public async Task<Customer> Create(Customer customer)
        {
            _customerRepository.Create(customer);
            await _unitOfWork.CommitAsync();
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

            _saleRepository.Create(sale);

            foreach (var saleDtoSaleDetailDto in saleDto.SaleDetailDtos)
                _saleDetailRepository.Create(new SaleDetail
                {
                    SaleId = sale.Id,
                    ProductId = saleDtoSaleDetailDto.ProductId,
                    Quantity = saleDtoSaleDetailDto.Quantity
                });

            await _unitOfWork.CommitAsync();
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
                    SaleDetailDtos = saleDetails.Select(x => new SaleDetailDto
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