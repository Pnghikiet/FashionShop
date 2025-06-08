using FashionShop.Application.DTOS;
using FashionShop.Application.Interfaces;
using FashionShop.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Account.Queries.GetCurrentUser
{
    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserQuery, UserDto>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _user;
        private readonly ITokenService _tokenService;

        public GetCurrentUserHandler(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> user, ITokenService tokenService)
        {
            _httpContextAccessor = httpContextAccessor;
            _user = user;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var email = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            if (email is null) throw new UnauthorizedAccessException("User not logged in");

            var user = await _user.FindByEmailAsync(email);

            var role = await _user.GetRolesAsync(user);

            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                Token = _tokenService.CreateToken(user,role)
            };
        }
    }
}
