using System.Linq.Expressions;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Domain.Entity;
using EightFigures.Contacts.Service.Repository.Base;

namespace EightFigures.Contacts.Service.Repository
{
    public interface IUserRepository: ISelectableRepository<User>, IInsertableRepository<User>
    {
        Task<UserInfoDto?> GetInfo(Expression<Func<User, bool>> predicate, Expression<Func<User, UserInfoDto>> select);
    }
}
