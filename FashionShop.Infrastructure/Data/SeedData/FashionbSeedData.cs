using FashionShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FashionShop.Infrastructure.Data.SeedData
{
    public static class FashionbSeedData
    {
        public static async Task SeedDataAsync(FashionDbContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brands = new List<ProductBrand>
                {
                    new ProductBrand{Name = "Nike"},
                    new ProductBrand{Name = "Puma"},
                    new ProductBrand{Name = "Adidas"},
                };
                context.ProductBrands.AddRange(brands);

                await context.SaveChangesAsync();
            }
            if(!context.ProductTypes.Any())
            {
                var type = new List<ProductType>
                {
                    new ProductType{Name = "Giày"},
                    new ProductType{Name = "Áo"},
                    new ProductType{Name = "Quần"},
                };

                context.ProductTypes.AddRange(type);

                await context.SaveChangesAsync();
            }
            if (!context.ProductSubTypes.Any())
            {
                var subTypes = new List<ProductSubType>
                {
                    new ProductSubType{Name = "Giày Thể Thao",ProductTypeId = 1},
                    new ProductSubType{Name = "Giày Casual", ProductTypeId = 1},
                    new ProductSubType{Name = "Áo thể thao", ProductTypeId = 2},
                    new ProductSubType{Name = "Áo Casual", ProductTypeId = 2},
                    new ProductSubType{Name = "Quần thể thao", ProductTypeId = 3},
                    new ProductSubType{Name = "Quần Casual", ProductTypeId = 3},
                };
                context.ProductSubTypes.AddRange(subTypes);

                await context.SaveChangesAsync();
            }
            if (!context.Products.Any())
            {
                var productData = File.ReadAllText("../FashionShop.Infrastructure/Data/SeedData/SeedDataFile/Products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productData);

               context.Products.AddRange(products);

                await context.SaveChangesAsync();
            }
        }
    }
}
