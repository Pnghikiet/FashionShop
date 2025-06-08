using FashionShop.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Account.Command.UserLogin
{
    public class UserLoginQuery : IRequest<UserDto>
    {
        public LoginDto Login { get; set; }

        public UserLoginQuery(LoginDto login)
        {
            Login = login;
        }



    }
}
