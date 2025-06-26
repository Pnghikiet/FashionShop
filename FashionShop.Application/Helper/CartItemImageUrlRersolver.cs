using AutoMapper;
using FashionShop.Application.DTOS;
using FashionShop.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Helper
{
    public class CartItemImageUrlRersolver : IValueResolver<CartItem, CartItemDto, string>
    {
        private readonly IConfiguration _config;

        public CartItemImageUrlRersolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(CartItem source, CartItemDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.Product.ImageUrl))
            {
                return _config["ApiUrl"] + source.Product.ImageUrl;
            }

            return null;
        }
    }
}
