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

namespace FashionShop.Application.UseCases.Products.Queries.GetProductSubTypes
{
    public class GetProductSubTypesHanlder : IRequestHandler<GetProductSubTypesQuery, List<ProductSubTypeDto>>
    {
        private IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetProductSubTypesHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductSubTypeDto>> Handle(GetProductSubTypesQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductSubTypeWithType();

            var productSubTypeDto = await _unitOfWork.ProductSubTypes.ListAsync(spec);

            return _mapper.Map<List<ProductSubType>, List<ProductSubTypeDto>>(productSubTypeDto);
        }
    }
}
