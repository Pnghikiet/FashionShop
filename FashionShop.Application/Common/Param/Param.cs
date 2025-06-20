﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Common.Param
{
    public class Param
    {
        public int? BrandId { get; set; }

        public int? SubTypeId { get; set; }

        public int? TypeId {  get; set; }

        public string Sort { get; set; } = "";

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 12;

        public string? Search {  get; set; }

        public string? Gender { get; set; }
    }
}
