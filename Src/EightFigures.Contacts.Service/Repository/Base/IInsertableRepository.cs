using EightFigures.Contacts.Domain.Entity;

namespace EightFigures.Contacts.Service.Repository.Base
{
    public interface IInsertableRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> Ins(TEntity entity);
    }
}
