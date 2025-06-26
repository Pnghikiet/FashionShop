using FashionShop.Application.Interfaces;
using FashionShop.Application.Specifications;
using FashionShop.Application.UseCases.Carts.Command.DeleteCartByUSerId;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Carts.Command.DeleteCartByUserId
{
    public class DeleteCartByUserIdHanlder : IRequestHandler<DeleteCartByUserIdQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCartByUserIdHanlder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new CartWithCartItems(request.userId);

            var cart = await _unitOfWork.Carts.GetCartByUserIdAsyncWithSpec(spec);

            if (cart != null)
            {
                var result = await _unitOfWork.Carts.DeleteCartAsync(cart);

                return result;
            }

            return false;
        }
    }
}
