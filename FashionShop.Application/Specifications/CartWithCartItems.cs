using FashionShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Specifications
{
    public class CartWithCartItems : BaseSpecification<Cart>
    {
        public CartWithCartItems(string userId) : base(x => x.UserId == userId)
        {
            AddIncludeString("Items.Product");
        }
    }
}
