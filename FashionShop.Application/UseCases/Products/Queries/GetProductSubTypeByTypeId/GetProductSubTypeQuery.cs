using FashionShop.Application.DTOS;
using FashionShop.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Products.Queries.GetProductSubTypeByTypeId
{
    public class GetProductSubTypeByTypeIdQuery : IRequest<List<ProductSubTypeDto>>
    {
        public int id { get; set; }

        public GetProductSubTypeByTypeIdQuery(int id) 
        {
            this.id = id;
        }
    }
}
