using FashionShop.Application.DTOS;
using FashionShop.Application.Interfaces;
using FashionShop.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Account.Command.UserLogin
{
    public class UserLoginHandler : IRequestHandler<UserLoginQuery, UserDto>
    {
        private readonly UserManager<AppUser> _user;
        private readonly SignInManager<AppUser> _signin;
        private readonly ITokenService _tokenService;

        public UserLoginHandler(UserManager<AppUser> user, SignInManager<AppUser> signin, ITokenService tokenService)
        {
            _user = user;
            _signin = signin;
            _tokenService = tokenService;
        }

        public async Task<UserDto> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _user.FindByEmailAsync(request.Login.Email);

            if (user == null)
                throw new Exception();

            var result = await _signin.CheckPasswordSignInAsync(user, request.Login.Password, false);

            if (!result.Succeeded)
                throw new Exception();

            var role = await _user.GetRolesAsync(user);

            return new UserDto
            {
                UserId = user.Id,
                Email = request.Login.Email,
                Token = _tokenService.CreateToken(user,role),
                DisplayName = user.DisplayName
            };
        }
    }
}
