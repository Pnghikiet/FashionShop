using AutoMapper;
using FashionShop.Application.DTOS;
using FashionShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<ProductSubType, ProductSubTypeDto>()
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Id));
            CreateMap<ProductBrand, ProductBrandDto>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ProductSubType, opt => opt.MapFrom(src => src.ProductSubType))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<ProductImageUrlResolver>());

            CreateMap<Cart, CartDto>();
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.ImageUrl))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<CartItemImageUrlRersolver>());
            
        }
    }
}
