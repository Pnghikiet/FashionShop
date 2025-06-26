using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Carts.Command.RemoveItemFromCart
{
    public class RemoveItemFromCartQuery : IRequest<bool>
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }

        public RemoveItemFromCartQuery(string userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }
}
