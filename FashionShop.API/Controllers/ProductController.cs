using FashionShop.Application.Common.Param;
using FashionShop.Application.DTOS;
using FashionShop.Application.UseCases.Products.Queries.GetProductById;
using FashionShop.Application.UseCases.Products.Queries.GetProducts;
using FashionShop.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
