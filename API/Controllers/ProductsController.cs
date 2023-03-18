using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public StoreContext StoreContext { get; }

        public ProductsController(StoreContext storeContext)
        {
            StoreContext = storeContext;
        }

        [HttpGet]
        [Route("")]
        [Route("/index")]
        public async Task<ActionResult<List<Product>>> index()
        {
            return await this.StoreContext.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        [Route("/details/{id}")]
        public async Task<ActionResult<Product>> details(int id)
        {
            return await this.StoreContext.Products.Where(prod => prod.Id == id).FirstOrDefaultAsync();
        }
    }
}
