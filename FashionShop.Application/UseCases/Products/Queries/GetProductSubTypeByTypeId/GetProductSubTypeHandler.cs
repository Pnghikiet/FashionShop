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

namespace FashionShop.Application.UseCases.Products.Queries.GetProductSubTypeByTypeId
{
    public class GetProductSubTypeHandler : IRequestHandler<GetProductSubTypeByTypeIdQuery, List<ProductSubTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetProductSubTypeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductSubTypeDto>> Handle(GetProductSubTypeByTypeIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductSubTypeWithType(request.id);

            var productSubType = await _unitOfWork.ProductSubTypes.ListAsync(spec);

            return _mapper.Map<List<ProductSubType>, List<ProductSubTypeDto>>(productSubType);
        }
    }
}
