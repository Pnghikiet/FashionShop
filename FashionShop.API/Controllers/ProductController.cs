using FashionShop.Application.Common.Param;
using FashionShop.Application.DTOS;
using FashionShop.Application.UseCases.Products.Queries.GetProductBrand;
using FashionShop.Application.UseCases.Products.Queries.GetProductById;
using FashionShop.Application.UseCases.Products.Queries.GetProducts;
using FashionShop.Application.UseCases.Products.Queries.GetProductSubTypeByTypeId;
using FashionShop.Application.UseCases.Products.Queries.GetProductSubTypes;
using FashionShop.Application.UseCases.Products.Queries.GetProductTypes;
using FashionShop.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FashionShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProduct([FromQuery] Param param)
        {
            var query = new GetProductsQuery(param);

            var productDtos = await _mediator.Send(query);

            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var query = new GetProductByIdQuery(id);

            var productDto = await _mediator.Send(query);

            return Ok(productDto);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrandDto>>> GetProductBrand()
        {
            var query = new GetProductBrandQuery();

            var productBrandDto = await _mediator.Send(query);

            return Ok(productBrandDto);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductTypeDto>>> GetProductType()
        {
            var query = new GetProductTypeQuery();

            var productTypeDto = await _mediator.Send(query);

            return Ok(productTypeDto);
        }

        [HttpGet("subtypes")]
        public async Task<ActionResult<IReadOnlyList<ProductSubTypeDto>>> GetProductSubTypes()
        {
            var query = new GetProductSubTypesQuery();

            var productSubTypeDto = await _mediator.Send(query);

            return Ok(productSubTypeDto);
        }

        [HttpGet("subtypes/{id}")]
        public async Task<ActionResult<IReadOnlyList<ProductSubTypeDto>>> GetProductSubTypeByTypeId(int id)
        {
            var query = new GetProductSubTypeByTypeIdQuery(id);

            var productSubTypeDto = await _mediator.Send(query);

            return Ok(productSubTypeDto);
        }
    }
}
