using AutoMapper;
using FridgeManager.Shared.Models;
using ProductsService.EF.Entities;
using ProductsService.Models;

namespace ProductsService.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductForReturn>();

            CreateMap<ProductForManipulation, Product>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.ImageSource, opt => opt.Ignore())
                .ForMember(x => x.Name, opt => opt.Condition(x => x.Name is not null));

            CreateMap<Product, SharedProduct>()
                .ForMember(x => x.ActionType, opt => opt.Ignore());
        }
    }
}
