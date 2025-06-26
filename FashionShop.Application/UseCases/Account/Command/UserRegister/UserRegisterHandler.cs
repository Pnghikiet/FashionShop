using FashionShop.Application.DTOS;
using FashionShop.Application.Interfaces;
using FashionShop.Core.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Account.Command.UserRegister
{
    public class UserRegisterHandler : IRequestHandler<UserRegisterQuery, UserDto>
    {
        private readonly UserManager<AppUser> _user;
        private readonly SignInManager<AppUser> _signin;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public UserRegisterHandler(UserManager<AppUser> user, SignInManager<AppUser> signin, ITokenService tokenService, IConfiguration config)
        {
            _user = user;
            _signin = signin;
            _tokenService = tokenService;
            _config = config;
        }

        public async Task<UserDto> Handle(UserRegisterQuery request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                Email = request.Register.Email,
                UserName = request.Register.Email,
                DisplayName = request.Register.DisplayName
            };

            var emailexist = await _user.FindByEmailAsync(user.Email);

            if (emailexist != null)
                throw new Exception("Email này đã được đăng ký");

            var result = await _user.CreateAsync(user, request.Register.Password);

            if (!result.Succeeded)
                throw new Exception("Đăng ký thất bại");

            await _user.AddToRoleAsync(user, _config["Roles:Client"]);

            var role = await _user.GetRolesAsync(user);

            return new UserDto
            {
                UserId = user.Id,
                Email = user.Email,
                Token = _tokenService.CreateToken(user,role),
                DisplayName = user.DisplayName,
            };
        }
    }
}
