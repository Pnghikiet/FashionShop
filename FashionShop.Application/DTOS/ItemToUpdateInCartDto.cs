using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.DTOS
{
    public class ItemToUpdateInCartDto
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
