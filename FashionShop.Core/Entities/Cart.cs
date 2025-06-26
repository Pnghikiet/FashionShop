using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Core.Entities
{
    public class Cart
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; }

        public List<CartItem> Items { get;private set; } = new List<CartItem>();

        public Cart(string userId)
        {
            UserId = userId;
        }

        //public void AddOrUpdateItem(int productId, int quantity)
        //{
        //    var item = CartItems.FirstOrDefault(c => c.ProductId == productId);
        //    if (item == null)
        //        CartItems.Add()
        //}
    }
}
