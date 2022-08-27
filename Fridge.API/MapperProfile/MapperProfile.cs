﻿using AutoMapper;
using Entities.DTO.FridgeProducts;
using Entities.DTO.Fridges;
using Entities.DTO.Products;
using Entities.Models;

namespace zFridge.API.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Entities.Models.Fridge, FridgeForReturnDto>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.FridgeModel.Name))
                .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.FridgeModel.Year));

            CreateMap<FridgeForCreateDto, Entities.Models.Fridge>()
                .ForMember(dest => dest.FridgeModel, opts => opts.MapFrom(src => new FridgeModel { Name = src.ModelName, Year = src.ModelYear }));
            CreateMap<FridgeForUpdateDto, Entities.Models.Fridge>()
                .ForMember(dest => dest.FridgeModel, opts => opts.MapFrom(src => new FridgeModel { Name = src.ModelName, Year = src.ModelYear }))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<FridgeProductForManipulationDto, FridgeProduct>();
            CreateMap<FridgeProduct, FridgeProductForReturnDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name));


            CreateMap<Product, ProductForReturnDto>();
            CreateMap<ProductForUpdateDto, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<ProductForCreateDto, Product>();
        }
    }
}
