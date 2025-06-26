using FashionShop.Application.Interfaces;
using FashionShop.Application.Specifications;
using FashionShop.Core.Entities;
using FashionShop.Infrastructure.Data;
using FashionShop.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        protected readonly FashionDbContext _db;

        public CartRepository(FashionDbContext db)
        {
            _db = db;
        }

        public async Task AddItemToCartAsync(CartItem cartItem)
        {
            await _db.CartItems.AddAsync(cartItem);
            await _db.SaveChangesAsync();
        }

        public async Task<CartItem?> GetItemByProductIdAsyncWithSpec(ISpecification<CartItem> spec)
        {
            var cartItem = await SpecificationEvaluator<CartItem>.GetQuery(_db.CartItems.AsQueryable(), spec).FirstOrDefaultAsync();

            return cartItem == null ? null : cartItem;
        }

        public async Task RemoveItemFormCartAsync(CartItem cartITem)
        {
            _db.CartItems.Remove(cartITem);
            await _db.SaveChangesAsync();
        }

        public Task<Cart> UpdateCartAsync(string cartId)
        {
            throw new NotImplementedException();
        }

        public async Task UpddateCartItemAsync(CartItem cartItem)
        {
            _db.CartItems.Update(cartItem);
            await _db.SaveChangesAsync();
        }

        public async Task<Cart> CreateCartAsync(string userId)
        {
            var cartToCreate = new Cart(userId);

            await _db.Carts.AddAsync(cartToCreate);
            await _db.SaveChangesAsync();

            return cartToCreate;
        }

        public async Task<bool> DeleteCartAsync(Cart cartToDelete)
        {
            try
            {
                _db.Carts.Remove(cartToDelete);
                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Cart?> GetCartByUserIdAsyncWithSpec(ISpecification<Cart> spec)
        {
            var cart = await SpecificationEvaluator<Cart>.GetQuery(_db.Carts.AsQueryable(), spec).FirstOrDefaultAsync();

            return cart;
        }

    }
}
