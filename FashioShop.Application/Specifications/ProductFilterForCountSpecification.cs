using FashionShop.Application.Common.Param;
using FashionShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Specifications
{
    public class ProductFilterForCountSpecification : BaseSpecification<Product>
    {
        public ProductFilterForCountSpecification(Param param)
            : base(x =>
        (string.IsNullOrEmpty(param.Search) || x.Name.ToLower().Contains(param.Search.ToLower())) &&
        (!param.BrandId.HasValue || x.ProductBrandId == param.BrandId) &&
        (!param.SubTypeId.HasValue || x.ProductSubTypeId == param.SubTypeId))
        {
        }
    }
}
