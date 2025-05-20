using FashionShop.Application.Common.Param;
using FashionShop.Application.DTOS;
using FashionShop.Application.Helper;
using FashionShop.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<Pagination<ProductDto>>
    {
        public Param param { get; set; }

        public GetProductsQuery(Param param)
        {
            this.param = param;
        }
    }
}
