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

namespace FashionShop.Application.UseCases.Carts.Queries.GetCurrentCartByUserId
{
    public class GetCurrentUserByUserIdHandler : IRequestHandler<GetCurrentUserByUserIdQuery, CartDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetCurrentUserByUserIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CartDto?> Handle(GetCurrentUserByUserIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new CartWithCartItems(request.UserId);

            var cart = await _unitOfWork.Carts.GetCartByUserIdAsyncWithSpec(spec);

            if (cart == null)
                return null;

            return _mapper.Map<Cart, CartDto>(cart);
        }
    }
}
