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

namespace FashionShop.Application.UseCases.Products.Queries.GetProductTypes
{
    public class GetProductTypeHanlder : IRequestHandler<GetProductTypeQuery, List<ProductTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetProductTypeHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductTypeDto>> Handle(GetProductTypeQuery request, CancellationToken cancellationToken)
        {
            var productType = await _unitOfWork.ProductTypes.GetAllAsync();

            return _mapper.Map<List<ProductType>,List<ProductTypeDto>>(productType);
        }
    }
}
