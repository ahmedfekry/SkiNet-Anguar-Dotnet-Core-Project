using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public IProductRepository _iproductRepository { get; }

        public ProductsController(IProductRepository iproductRepository)
        {
            _iproductRepository = iproductRepository;
        }

        [HttpGet]
        [Route("")]
        [Route("/index")]
        public async Task<ActionResult<List<Product>>> index()
        {
            var products = await _iproductRepository.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        [Route("/details/{id}")]
        public async Task<ActionResult<Product>> details(int id)
        {
            var product = await _iproductRepository.GetProductByIdAsync(id);

            return product;
        }
    }
}
