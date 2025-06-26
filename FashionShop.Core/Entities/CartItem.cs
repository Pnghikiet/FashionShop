using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Core.Entities
{
    public class CartItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total => Quantity * Price;

        public string CartId { get; set; }

        public Cart Cart { get; set; }

        public Product Product { get; set; }

        public CartItem(int productId, int quantity, string cartId, decimal price)
        {
            ProductId = productId;
            Quantity = quantity;
            CartId = cartId;
            Price = price;
        }
    }
}
