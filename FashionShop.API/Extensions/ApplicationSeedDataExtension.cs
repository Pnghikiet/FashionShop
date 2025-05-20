using FashionShop.Infrastructure.Data;
using FashionShop.Infrastructure.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.API.Extensions
{
    public static class ApplicationSeedDataExtension
    {
        public static async Task SeedDataAsync(this WebApplication app)
        {
            var scope = app.Services.CreateScope();

            var provider = scope.ServiceProvider;

            var context = provider.GetService<FashionDbContext>();

            await context.Database.MigrateAsync();

            await FashionbSeedData.SeedDataAsync(context);

        }
    }
}
