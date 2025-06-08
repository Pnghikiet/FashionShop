using FashionShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Specifications
{
    public class ProductSubTypeWithType : BaseSpecification<ProductSubType>
    {
        public ProductSubTypeWithType()
        {
            AddInclude(x => x.ProductType);
        }

        public ProductSubTypeWithType(int id): base(x => x.ProductType.Id == id)
        {
            AddInclude(x => x.ProductType);
        }
    }
}
