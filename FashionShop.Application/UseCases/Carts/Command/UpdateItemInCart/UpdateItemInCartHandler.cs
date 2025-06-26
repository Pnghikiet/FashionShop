using AutoMapper;
using FashionShop.Application.DTOS;
using FashionShop.Application.Interfaces;
using FashionShop.Application.Specifications;
using FashionShop.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Carts.Command.AddItemToCart
{
    public class UpdateItemInCartHandler : IRequestHandler<UpdateItemInCartQuery, CartItemDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UpdateItemInCartHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CartItemDto?> Handle(UpdateItemInCartQuery request, CancellationToken cancellationToken)
        {
            var spec = new CartWithCartItems(request.ItemToAdd.UserId);

            var cart = await _unitOfWork.Carts.GetCartByUserIdAsyncWithSpec(spec);
            
            if(cart == null)
            {
                cart = await _unitOfWork.Carts.CreateCartAsync(request.ItemToAdd.UserId);
            }

            var product = await _unitOfWork.Products.GetByIdAsync(request.ItemToAdd.ProductId);

            if(product == null)
            {
                throw new Exception("Sản phẩm không tồn tại");
            }

            var cartItemSpec = new CartItemFromCart(cart.Id, request.ItemToAdd.ProductId);

            var cartItem = await _unitOfWork.Carts.GetItemByProductIdAsyncWithSpec(cartItemSpec);

            if(cartItem == null)
            {
                cartItem = new CartItem(request.ItemToAdd.ProductId, request.ItemToAdd.Quantity, cart.Id, product.Price);

                await _unitOfWork.Carts.AddItemToCartAsync(cartItem);

                return _mapper.Map<CartItem,CartItemDto>(cartItem);
            }
            else
            {
                cartItem.Quantity += request.ItemToAdd.Quantity;
                if(cartItem.Quantity <= 0)
                {
                    await _unitOfWork.Carts.RemoveItemFormCartAsync(cartItem);

                    return null;
                }
                else
                {
                    await _unitOfWork.Carts.UpddateCartItemAsync(cartItem);

                    return _mapper.Map<CartItem, CartItemDto>(cartItem);
                }
            }
        }
    }
}
