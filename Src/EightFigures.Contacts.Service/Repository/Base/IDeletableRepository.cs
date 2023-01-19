using System.Linq.Expressions;
using EightFigures.Contacts.Domain.Entity;

namespace EightFigures.Contacts.Service.Repository.Base
{
    public interface IDeletableRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task Del(TEntity entity);

        Task Del(int id);

        Task Del(Expression<Func<TEntity, bool>> predicate);
    }
}
