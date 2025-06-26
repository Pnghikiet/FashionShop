using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.DTOS
{
    public class CartDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public IReadOnlyList<CartItemDto> Items { get; set; }
    }
}
