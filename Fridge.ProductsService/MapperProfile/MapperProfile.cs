using AutoMapper;
using Fridge.ProductsService.Models;
using Fridge.Shared.Entities;

namespace Fridge.ProductsService.MapperProfile
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductForReturn>();

            CreateMap<ProductForManipulation, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
