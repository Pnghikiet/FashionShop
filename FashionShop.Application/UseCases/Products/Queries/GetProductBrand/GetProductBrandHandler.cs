using AutoMapper;
using FashionShop.Application.DTOS;
using FashionShop.Application.Interfaces;
using FashionShop.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Products.Queries.GetProductBrand
{
    public class GetProductBrandHandler : IRequestHandler<GetProductBrandQuery, List<ProductBrandDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductBrandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductBrandDto>> Handle(GetProductBrandQuery request, CancellationToken cancellationToken)
        {
            var productBrand = await _unitOfWork.ProductBrands.GetAllAsync();

            return _mapper.Map<List<ProductBrand>, List<ProductBrandDto>>(productBrand);
        }
    }
}
