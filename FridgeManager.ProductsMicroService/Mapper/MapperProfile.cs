using AutoMapper;
using FridgeManager.ProductsMicroService.EF.Entities;
using FridgeManager.ProductsMicroService.Models;
using FridgeManager.Shared.Models;

namespace FridgeManager.ProductsMicroService.Mapper
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
