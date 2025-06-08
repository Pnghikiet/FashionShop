using FashionShop.Application.Interfaces;
using FashionShop.Core.Entities;
using FashionShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FashionDbContext _db;

        private IGenericRepository<Product>? _productRepo;

        private IGenericRepository<ProductBrand>? _productBrandRepo;

        private IGenericRepository<ProductType>? _productTypeRepo;

        private IGenericRepository<ProductSubType>? _productSubTypeRepo;

        public UnitOfWork(FashionDbContext db)
        {
            _db = db;
        }

        public IGenericRepository<Product> Products => _productRepo ??= new GenericRepository<Product>(_db);

        public IGenericRepository<ProductBrand> ProductBrands => _productBrandRepo ??= new GenericRepository<ProductBrand>(_db);

        public IGenericRepository<ProductType> ProductTypes => _productTypeRepo ??= new GenericRepository<ProductType>(_db);

        public IGenericRepository<ProductSubType> ProductSubTypes => _productSubTypeRepo ??= new GenericRepository<ProductSubType>(_db);


        public async Task<int> Complete()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
