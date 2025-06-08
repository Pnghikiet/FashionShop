using FashionShop.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Products.Queries.GetProductSubTypes
{
    public class GetProductSubTypesQuery : IRequest<List<ProductSubTypeDto>>
    {
        public GetProductSubTypesQuery()
        {
        }
    }
}
