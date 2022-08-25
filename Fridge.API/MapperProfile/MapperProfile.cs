using AutoMapper;
using Entities.DTO.Fridge;

namespace zFridge.API.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Entities.Models.Fridge, FridgeDto>()
                .ForMember(x => x.ModelName, opt => opt.MapFrom(c => c.FridgeModel.Name))
                .ForMember(x => x.ModelYear, opt => opt.MapFrom(c => c.FridgeModel.Year));
        }
    }
}
