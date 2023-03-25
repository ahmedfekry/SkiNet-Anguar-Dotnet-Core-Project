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
            return await _StoreContext.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _StoreContext.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Product> GetProductByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync()
        {
            return await _StoreContext.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync()
        {
           return await (_StoreContext.ProductTypes.ToListAsync());
        }
    }
}
