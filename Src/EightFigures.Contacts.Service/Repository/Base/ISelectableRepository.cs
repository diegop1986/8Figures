using System.Linq.Expressions;
using EightFigures.Contacts.Domain.Entity;

namespace EightFigures.Contacts.Service.Repository.Base
{
    public interface ISelectableRepository<TEntity>
        where TEntity : BaseEntity
    {
       Task<TEntity?> Get(int id);

        Task<TEntity?> GetAsNoTracking(int id);

        Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> GetAsNoTracking(Expression<Func<TEntity, bool>> predicate);

        Task<IList<TEntity>> GetAll();

        Task<IList<TEntity>> GetAllAsNoTracking();

        Task<IList<TEntity>> GetMany(Expression<Func<TEntity, bool>> predicate);

        Task<IList<TEntity>> GetManyAsNoTracking(Expression<Func<TEntity, bool>> predicate);

        Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);
    }
}
