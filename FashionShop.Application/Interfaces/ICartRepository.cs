using FashionShop.Application.Specifications;
using FashionShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> CreateCartAsync(string userId);
        Task<Cart?> GetCartByUserIdAsyncWithSpec(ISpecification<Cart> spec);
        Task<Cart> UpdateCartAsync(string cartId);
        Task<bool> DeleteCartAsync(Cart cartToDelete);
        Task<CartItem?> GetItemByProductIdAsyncWithSpec(ISpecification<CartItem> spec);
        Task AddItemToCartAsync(CartItem cartItem);
        Task RemoveItemFormCartAsync(CartItem cartITem);
        Task UpddateCartItemAsync(CartItem cartItem);
    }
}
