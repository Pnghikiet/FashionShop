using FashionShop.Application.Common.Param;
using FashionShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Specifications
{
    public class ProductWithBrandAndType : BaseSpecification<Product>
    {
        public ProductWithBrandAndType(Param param) : base(x =>
        (string.IsNullOrEmpty(param.Search) || x.Name.ToLower().Contains(param.Search.ToLower()))&&
        (!param.BrandId.HasValue || x.ProductBrandId == param.BrandId) &&
        (!param.SubTypeId.HasValue || x.ProductSubTypeId == param.SubTypeId)&&
        (!param.TypeId.HasValue || x.ProductSubType.ProductTypeId == param.TypeId)&&
        (string.IsNullOrEmpty(param.Gender) || x.Gender.ToLower().Equals(param.Gender.ToLower())))
        {
            AddIncludeString("ProductSubType.ProductType");

            AddInclude(x => x.ProductBrand);

            ApplyPaging(param.PageSize, (param.PageIndex - 1) * param.PageSize);

            switch (param.Sort.ToLower())
            {
                case "desc":
                    AddORderByDescending(x => x.Name);
                    break;
                case "pricedesc":
                    AddORderByDescending(x => x.Price);
                    break;
                case "priceasc":
                    AddOrderby(x => x.Price);
                    break;
                default:
                    AddOrderby(x => x.Name);
                    break;
            }
        }

        public ProductWithBrandAndType(int id) :base(x => x.Id ==id)
        {
            AddIncludeString("ProductSubType.ProductType");

            AddInclude(x => x.ProductBrand);
        }
    }
}
