using FashionShop.Application.DTOS;
using FashionShop.Application.UseCases.Carts.Command.AddItemToCart;
using FashionShop.Application.UseCases.Carts.Command.DeleteCartByUSerId;
using FashionShop.Application.UseCases.Carts.Command.RemoveItemFromCart;
using FashionShop.Application.UseCases.Carts.Queries.GetCurrentCartByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CartDto?>> GetCurrentCart(string userId)
        {
            var query = new GetCurrentUserByUserIdQuery(userId);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CartItemDto>> UpdateItemInCart(ItemToUpdateInCartDto itemAddToCartDto)
        {
            try
            {
                var query = new UpdateItemInCartQuery(itemAddToCartDto);

                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new {message =  ex.Message});
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteCart(string userId)
        {
            var query = new DeleteCartByUserIdQuery(userId);

            var result = await _mediator.Send(query);

            return result ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{userId}/{productId}")]
        public async Task<ActionResult> DeleteItemFromart(string userId, int productId)
        {
            var query = new RemoveItemFromCartQuery(userId, productId);

            var result = await _mediator.Send(query);

            return result? Ok(result) : BadRequest(result);
        }

    }
}
