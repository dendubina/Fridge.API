using AutoMapper;
using FridgeManager.Shared.Models;
using FridgesService.DTO.FridgeProducts;
using FridgesService.DTO.Fridges;
using FridgesService.DTO.Owner;
using FridgesService.EF.Entities;

namespace FridgesService.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Fridge, FridgeForReturnDto>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.FridgeModel.Name))
                .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.FridgeModel.Year))
                .ForMember(dest => dest.FridgeProducts, opt => opt.MapFrom(src => src.Products));

            CreateMap<FridgeForCreateDto, Fridge>()
                .ForMember(dest => dest.FridgeModel, opts => opts.MapFrom(src => new FridgeModel { Name = src.ModelName, Year = src.ModelYear }))
                .ForMember(dest => dest.Products, opts => opts.MapFrom(src => src.FridgeProducts));

            CreateMap<FridgeForUpdateDto, Fridge>()
                .ForMember(dest => dest.FridgeModel, opts => opts.MapFrom(src => new FridgeModel { Name = src.ModelName, Year = src.ModelYear }))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<FridgeProductForManipulationDto, FridgeProduct>();

            CreateMap<FridgeProduct, FridgeProductForReturnDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ImageSource, opt => opt.MapFrom(src => src.Product.ImageSource));

            CreateMap<Owner, OwnerForReturnDto>();

            CreateMap<SharedProduct, Product>();

            CreateMap<SharedUser, Owner>();
        }
    }
}
