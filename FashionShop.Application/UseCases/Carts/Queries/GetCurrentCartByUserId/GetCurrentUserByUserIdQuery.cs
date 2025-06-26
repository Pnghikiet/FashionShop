using FashionShop.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Carts.Queries.GetCurrentCartByUserId
{
    public class GetCurrentUserByUserIdQuery : IRequest<CartDto?>
    {
        public string UserId {  get; set; }

        public GetCurrentUserByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
