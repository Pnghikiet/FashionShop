﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Gender {  get; set; }

        public int ProductSubTypeId { get; set; }

        public ProductSubType ProductSubType {get; set;}

        public int ProductBrandId {  get; set; }

        public ProductBrand ProductBrand { get; set; }
    }
}
