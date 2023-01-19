using AutoMapper;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Domain.Entity;

namespace EightFigures.Contacts.Service.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>()
                .ForMember(dest => dest.UserCreated, src => src.MapFrom(x => x.LogIn));
        }
    }
}
