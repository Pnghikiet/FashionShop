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

namespace FashionShop.Application.UseCases.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetProductByIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductWithBrandAndType(request.ProductId);

            var product = await _unitOfWork.Products.GetAsync(spec);

            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
