using AutoMapper;
using Entities.DTO.FridgeProducts;
using Entities.DTO.Fridges;
using Entities.EF.Entities;

namespace FridgeManager.FridgesMicroService.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Entities.EF.Entities.Fridge, FridgeForReturnDto>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.FridgeModel.Name))
                .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.FridgeModel.Year))
                .ForMember(dest => dest.FridgeProducts, opt => opt.MapFrom(src => src.Products));


            CreateMap<FridgeForCreateDto, Entities.EF.Entities.Fridge>()
                .ForMember(dest => dest.FridgeModel, opts => opts.MapFrom(src => new FridgeModel { Name = src.ModelName, Year = src.ModelYear }))
                .ForMember(dest => dest.Products, opts => opts.MapFrom(src => src.FridgeProducts));
            CreateMap<FridgeForUpdateDto, Entities.EF.Entities.Fridge>()
                .ForMember(dest => dest.FridgeModel, opts => opts.MapFrom(src => new FridgeModel { Name = src.ModelName, Year = src.ModelYear }))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<FridgeProductForManipulationDto, FridgeProduct>();
            CreateMap<FridgeProduct, FridgeProductForReturnDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ImageSource, opt => opt.MapFrom(src => src.Product.ImageSource));
        }
    }
}
