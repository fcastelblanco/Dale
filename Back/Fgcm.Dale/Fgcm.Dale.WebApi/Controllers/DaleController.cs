using System.Threading.Tasks;
using Fgcm.Dale.ApplicationService;
using Fgcm.Dale.Domain.Dtos;
using Fgcm.Dale.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fgcm.Dale.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DaleController : ControllerBase
    {
        private readonly IDaleApplicationService _daleApplicationService;

        public DaleController(IDaleApplicationService daleApplicationService)
        {
            _daleApplicationService = daleApplicationService;
        }

        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome !");
        }

        [Route("createProductAsync")]
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(Product product)
        {
            var data = await _daleApplicationService.CreateAsync(product);
            return Ok(data);
        }

        [Route("createProduct")]
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var data = _daleApplicationService.Create(product);
            return Ok(data);
        }

        [Route("createCustomer")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            var data = await _daleApplicationService.Create(customer);
            return Ok(data);
        }

        [Route("getAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var data = await _daleApplicationService.GetAllProduct();
            return Ok(data);
        }

        [Route("getAllCustomers")]
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var data = await _daleApplicationService.GetAllCustomer();
            return Ok(data);
        }

        [Route("getAllSales")]
        [HttpGet]
        public async Task<IActionResult> GetAllSales()
        {
            var data = await _daleApplicationService.GetAllSales();
            return Ok(data);
        }

        [Route("createSale")]
        [HttpPost]
        public async Task<IActionResult> CreateSale(SaleDto saleDto)
        {
            var data = await _daleApplicationService.Create(saleDto);
            return Ok(data);
        }
    }
}