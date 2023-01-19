using EightFigures.Contacts.Domain.Entity;

namespace EightFigures.Contacts.Service.Repository.Base
{
    public interface IUpdatableRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task Upd(TEntity entity);
    }
}
