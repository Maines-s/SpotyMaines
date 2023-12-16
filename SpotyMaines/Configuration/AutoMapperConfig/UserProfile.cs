using AutoMapper;
using SpotyMaines.Domain.AutenticationModule;
using SpotyMaines.ViewModel.AuthModule;

namespace SpotyMaines.Configuration.AutoMapperConfig
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Login));
        }
    }
}
