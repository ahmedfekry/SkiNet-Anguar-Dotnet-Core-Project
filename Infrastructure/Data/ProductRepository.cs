using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public StoreContext _StoreContext { get; }
        public ProductRepository(StoreContext storeContext)
        {
            _StoreContext = storeContext;
        }


        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            return await _StoreContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _StoreContext.Products.FindAsync(id);
        }

        public Task<Product> GetProductByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
