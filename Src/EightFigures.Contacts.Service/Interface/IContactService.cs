using EightFigures.Contacts.Service.Dto;

namespace EightFigures.Contacts.Service.Interface
{
    public interface IContactService
    {
        Task Add(ContactAddDto dto);

        Task Upd(ContactUpdDto dto);

        Task Del(ContactDelDto dto);

        Task<IEnumerable<ContactInfoDto>> Get(ContactGetDto dto);
    }
}
