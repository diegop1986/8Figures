using System.Linq.Expressions;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Domain.Entity;
using EightFigures.Contacts.Service.Repository;

namespace EightFigures.Contacts.Persistence.Repository
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(IContactsDbContext dbContext) : base(dbContext) { }

        public async Task<UserInfoDto?> GetInfo(Expression<Func<User, bool>> predicate, Expression<Func<User, UserInfoDto>> select) => await Get(predicate, select);
    }
}
