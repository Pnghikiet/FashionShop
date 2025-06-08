using FashionShop.Application.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> GetAsync(ISpecification<T> spec);
        Task<int> CountAsyncWithSpec(ISpecification<T> spec);
    }
}
