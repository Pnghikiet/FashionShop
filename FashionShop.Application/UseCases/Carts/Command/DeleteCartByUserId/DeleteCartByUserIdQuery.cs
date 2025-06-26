using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.UseCases.Carts.Command.DeleteCartByUSerId
{
    public class DeleteCartByUserIdQuery : IRequest<bool>
    {
        public string userId { get; set; }

        public DeleteCartByUserIdQuery(string userId)
        {
            this.userId = userId;
        }
    }
}
