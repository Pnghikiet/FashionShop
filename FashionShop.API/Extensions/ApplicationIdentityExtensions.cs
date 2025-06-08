using FashionShop.Application.Interfaces;
using FashionShop.Core.Entities.Identity;
using FashionShop.Infrastructure.Identity;
using FashionShop.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FashionShop.API.Extensions
{
    public static class ApplicationIdentityExtensions
    {
        public static IServiceCollection IdentityExtensionService(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddSingleton<TimeProvider>(TimeProvider.System);
            services.AddScoped<ITokenService, TokenService>();

            services.AddIdentityCore<AppUser>(options =>
            {

            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddSignInManager<SignInManager<AppUser>>();




            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidateIssuer = true,
                        ValidIssuer = config["Token:Issuer"],
                        ValidateAudience = false
                    };
                });
            services.AddAuthorization();
            return services;
        }
    }
}
