using System.Linq.Expressions;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Domain.Entity;
using EightFigures.Contacts.Service.Repository;

namespace EightFigures.Contacts.Persistence.Repository
{
    public class ContactRepository: BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(IContactsDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<ContactInfoDto>> GetManyInfo(Expression<Func<Contact, bool>> predicate, Expression<Func<Contact, ContactInfoDto>> select) => await GetMany(predicate, select);
    }
}
