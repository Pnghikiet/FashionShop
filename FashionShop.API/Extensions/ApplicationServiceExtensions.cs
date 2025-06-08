using FashionShop.Application;
using FashionShop.Application.Interfaces;
using FashionShop.Infrastructure.Data;
using FashionShop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FashionShop.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection ApplicationExtensionService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<FashionDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(ExtensionMarker).Assembly);

            services.AddCors(opt => opt.AddPolicy("AllowCors", policy =>
            {
                policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            }));

            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ExtensionMarker).Assembly));

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsAllow", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
