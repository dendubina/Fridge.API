using AutoMapper;
using FridgeManager.ProductsMicroService.EF.Entities;
using FridgeManager.Shared.Models;

namespace FridgeManager.ProductsMicroService.Models.Mapper
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
