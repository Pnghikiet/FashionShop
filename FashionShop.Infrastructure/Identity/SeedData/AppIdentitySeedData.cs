using FashionShop.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Infrastructure.Identity.SeedData
{
    public class AppIdentitySeedData
    {
        public static async Task SeeddDataAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminRole = "Admin";
            var clientRole = "Client";

            if(!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
                await roleManager.CreateAsync(new IdentityRole(clientRole));
            }

            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    UserName = "Pnk",
                    DisplayName = "Pnk",
                    Address = "HCM",
                    Email = "pnk@test.com",
                    PhoneNumber = "0902165143"
                };

                var admin = new AppUser
                {
                    UserName = "Admin",
                    DisplayName = "Admin",
                    Address = "Admin",
                    Email = "admin@admin.com",
                };

                await userManager.CreateAsync(user,"Pnk17092001!");
                await userManager.AddToRoleAsync(user, clientRole);

                await userManager.CreateAsync(admin, "Admin123456789!");
                await userManager.AddToRoleAsync(admin, adminRole);
            }


        }
    }
}
