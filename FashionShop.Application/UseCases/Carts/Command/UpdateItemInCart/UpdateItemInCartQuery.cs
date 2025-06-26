using FashionShop.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Carts.Command.AddItemToCart
{
    public class UpdateItemInCartQuery : IRequest<CartItemDto?>
    {
        public ItemToUpdateInCartDto ItemToAdd { get; set; }

        public UpdateItemInCartQuery(ItemToUpdateInCartDto itemToAdd)
        {
            ItemToAdd = itemToAdd;
        }
    }
}
