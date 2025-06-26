using FashionShop.Application.Interfaces;
using FashionShop.Application.Specifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Carts.Command.RemoveItemFromCart
{
    public class RemoveItemFromCartHandler : IRequestHandler<RemoveItemFromCartQuery,bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveItemFromCartHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RemoveItemFromCartQuery request, CancellationToken cancellationToken)
        {
            var spec = new CartWithCartItems(request.UserId);

            var cart = await _unitOfWork.Carts.GetCartByUserIdAsyncWithSpec(spec);

            if (cart == null)
                return false;

            var cartItemSpec = new CartItemFromCart(cart.Id, request.ProductId);

            var cartitem = await _unitOfWork.Carts.GetItemByProductIdAsyncWithSpec(cartItemSpec);

            if (cartitem == null)
                return false;

            await _unitOfWork.Carts.RemoveItemFormCartAsync(cartitem);

            return true;
        }
    }
}
