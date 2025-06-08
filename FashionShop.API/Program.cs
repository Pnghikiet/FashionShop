using FashionShop.API.Extensions;
using FashionShop.Core.Entities.Identity;
using FashionShop.Infrastructure.Data.SeedData;
using FashionShop.Infrastructure.Data;
using FashionShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FashionShop.Infrastructure.Identity.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ApplicationExtensionService(builder.Configuration);
builder.Services.IdentityExtensionService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseCors("CorsAllow");

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await app.SeedDataAsync();

app.Run();
