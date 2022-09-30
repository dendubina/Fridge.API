﻿using AutoMapper;
using Fridge.ProductsService.EF.Entities;
using Fridge.Shared.Models;

namespace Fridge.ProductsService.Models.Mapper
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductForReturn>();

            CreateMap<ProductForManipulation, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Product, SharedProduct>();
        }
    }
}