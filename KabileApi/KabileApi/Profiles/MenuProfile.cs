using AutoMapper;

namespace KabileApi.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Entities.Menu, Models.MenuDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
                )
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
                )
            .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price)
                );
            CreateMap<Models.MenuDto, Entities.Menu>()
                 .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)
                )
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
                )
            .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price)
                );
        }
    }
}
