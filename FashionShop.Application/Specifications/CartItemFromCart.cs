using FashionShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Specifications
{
    public class CartItemFromCart : BaseSpecification<CartItem>
    {
        public CartItemFromCart(string CartId, int productId) : base(x => x.CartId == CartId && x.ProductId == productId)
        {
            AddInclude(x => x.Product);
        }
    }
}
