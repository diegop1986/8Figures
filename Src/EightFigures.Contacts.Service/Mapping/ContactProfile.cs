using AutoMapper;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Domain.Entity;

namespace EightFigures.Contacts.Service.Mapping
{
    public class ContactProfile: Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactAddDto, Contact>()
                .ForMember(dest => dest.UserCreated, src => src.MapFrom(x => x.UserRequest));

            CreateMap<ContactUpdDto, Contact>()
                .ForMember(dest => dest.UserUpdated, src => src.MapFrom(x => x.UserRequest))
                .AfterMap((dto, entity) => entity.UpdatedAt = DateTimeOffset.UtcNow);
        }
    }
}
