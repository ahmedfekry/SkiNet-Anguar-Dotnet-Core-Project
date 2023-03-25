using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public StoreContextSeed() { }

        public static async Task SeedAsync(StoreContext storeContext)
        {

            if (!storeContext.ProductBrands.Any())
            {
                var productBrandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandsData);
                storeContext.ProductBrands.AddRange(productBrands);
            }

            if (!storeContext.ProductTypes.Any())
            {
                var productTypeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);
                storeContext.ProductTypes.AddRange(productTypes);
            }


            if (!storeContext.Products.Any())
            {
                var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                storeContext.Products.AddRange(products);
            }

            if (storeContext.ChangeTracker.HasChanges())
            {
                await storeContext.SaveChangesAsync();
            }

        }
    }
}
