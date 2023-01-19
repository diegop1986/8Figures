using AutoMapper;
using System.Linq.Expressions;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Domain.Entity;
using EightFigures.Contacts.Domain.Extension;
using EightFigures.Contacts.Service.Interface;
using EightFigures.Contacts.Service.Repository;
using EightFigures.Contacts.Domain.CustomException.NotFound;

namespace EightFigures.Contacts.Service.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;
        private readonly IMapper mapper;
        private readonly IValidationService validationService;

        public ContactService(IContactRepository contactRepository, IValidationService validationService, IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.validationService = validationService;
            this.mapper = mapper;
        }

        public async Task Add(ContactAddDto dto)
        {
            validationService.EnsureValid(dto);
            var @new = mapper.Map<Contact>(dto);
            await contactRepository.Ins(@new);
        }

        public async Task Upd(ContactUpdDto dto)
        {
            validationService.EnsureValid(dto);

            var entity = await contactRepository.Get(dto.Id);
            if (entity is null) throw new ContactNotFoundException();

            mapper.Map(dto, entity);
            await contactRepository.Upd(entity);
        }

        public async Task Del(ContactDelDto dto)
        {
            validationService.EnsureValid(dto);

            var entity = await contactRepository.Get(dto.Id);
            if (entity is null) throw new ContactNotFoundException();

            await contactRepository.Del(entity);
        }

        public async Task<IEnumerable<ContactInfoDto>> Get(ContactGetDto dto)
        {
            Expression<Func<Contact, bool>> where = x => x.UserId == dto.UserId;

            if (!string.IsNullOrEmpty(dto.Name))
                where = where.Merge(x => x.FullName.Contains(dto.Name));

            if (!string.IsNullOrEmpty(dto.Phone))
                where = where.Merge(x => x.PhoneNumber.Contains(dto.Phone));

            return await contactRepository.GetManyInfo(where, x => new ContactInfoDto { Id = x.Id, Name = x.FullName, Phone = x.PhoneNumber });
        }
    }
}
