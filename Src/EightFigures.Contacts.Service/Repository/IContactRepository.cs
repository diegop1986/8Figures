using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Domain.Entity;
using EightFigures.Contacts.Service.Repository.Base;
using System.Linq.Expressions;

namespace EightFigures.Contacts.Service.Repository
{
    public interface IContactRepository: ISelectableRepository<Contact>, IUpdatableRepository<Contact>, IInsertableRepository<Contact>, IDeletableRepository<Contact>
    {
        Task<IEnumerable<ContactInfoDto>> GetManyInfo(Expression<Func<Contact, bool>> predicate, Expression<Func<Contact, ContactInfoDto>> select);
    }
}
