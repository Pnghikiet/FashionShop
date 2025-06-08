using FashionShop.Core.Entities.Identity;
using FashionShop.Infrastructure.Data;
using FashionShop.Infrastructure.Data.SeedData;
using FashionShop.Infrastructure.Identity;
using FashionShop.Infrastructure.Identity.SeedData;
using Microsoft.AspNetCore.Identity;
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
            using(var scope = app.Services.CreateScope())
            {

                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<FashionDbContext>();

                var userManager = services.GetRequiredService<UserManager<AppUser>>();

                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                var identitycontext = services.GetRequiredService<AppIdentityDbContext>();

                await context.Database.MigrateAsync();

                await identitycontext.Database.MigrateAsync();

                await FashionbSeedData.SeedDataAsync(context);

                await AppIdentitySeedData.SeeddDataAsync(userManager,roleManager);
            }
        }
    }
}
