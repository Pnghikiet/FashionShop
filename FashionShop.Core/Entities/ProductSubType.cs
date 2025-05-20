using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Core.Entities
{
    public class ProductSubType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(ProductType))]
        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }
    }
}
