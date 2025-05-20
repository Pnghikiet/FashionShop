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
                options.UseSqlServer(config.GetConnectionString("Default"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(ExtensionMarker).Assembly);

            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ExtensionMarker).Assembly));

            return services;
        }
    }
}
