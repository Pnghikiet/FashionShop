using FashionShop.Application.DTOS;
using FashionShop.Application.UseCases.Account.Command.UserLogin;
using FashionShop.Application.UseCases.Account.Command.UserRegister;
using FashionShop.Application.UseCases.Account.Queries.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FashionShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public AccountController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            try
            {
                var query = new UserLoginQuery(loginDto);

                var result = await _mediatR.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> register(RegisterDto registerDto)
        {
            try
            {
                var query = new UserRegisterQuery(registerDto);

                var result = await _mediatR.Send(query);

                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUSer()
        {
            var query = new GetCurrentUserQuery();

            var result = await _mediatR.Send(query);

            return Ok(result);
        }
    }
}
