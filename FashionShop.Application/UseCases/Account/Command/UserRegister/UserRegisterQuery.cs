using FashionShop.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Account.Command.UserRegister
{
    public class UserRegisterQuery : IRequest<UserDto>
    {
        public RegisterDto Register { get; set; }

        public UserRegisterQuery(RegisterDto register)
        {
            Register = register;
        }
    }
}
