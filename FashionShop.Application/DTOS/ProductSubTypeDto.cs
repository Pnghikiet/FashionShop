using FashionShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.DTOS
{
    public class ProductSubTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductType { get; set; }
    }
}
