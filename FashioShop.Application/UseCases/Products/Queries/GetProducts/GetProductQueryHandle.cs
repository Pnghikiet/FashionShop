using AutoMapper;
using FashionShop.Application.DTOS;
using FashionShop.Application.Helper;
using FashionShop.Application.Interfaces;
using FashionShop.Application.Specifications;
using FashionShop.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Products.Queries.GetProducts
{
    public class GetProductQueryHandle : IRequestHandler<GetProductsQuery, Pagination<ProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetProductQueryHandle(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Pagination<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductWithBrandAndType(request.param);

            var products = await _unitOfWork.Products.ListAsync(spec);

            var countspec = new ProductFilterForCountSpecification(request.param);

            var totalitem = await _unitOfWork.Products.CountAsyncWithSpec(countspec);

            var productDto = _mapper.Map<List<Product>, List<ProductDto>>(products);

            return new Pagination<ProductDto>(request.param.PageIndex, request.param.PageSize, totalitem,productDto);
        }
    }
}
