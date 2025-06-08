using FashionShop.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Account.Queries.GetCurrentUser
{
    public class GetCurrentUserQuery : IRequest<UserDto>
    {
        public GetCurrentUserQuery()
        {
        }
    }
}
