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
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender ? "Nữ" : "Nam"));
        }
    }
}
