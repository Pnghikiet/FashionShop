using FashionShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> Products { get; }
        IGenericRepository<ProductBrand> ProductBrands { get; }
        IGenericRepository<ProductType> ProductTypes { get; }
        Task<int> Complete();
    }
}
