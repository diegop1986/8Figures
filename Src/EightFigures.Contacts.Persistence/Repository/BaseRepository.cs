using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using EightFigures.Contacts.Domain.Entity;
using EightFigures.Contacts.Domain.CustomException.Internal;

namespace EightFigures.Contacts.Persistence.Repository
{
    public abstract class BaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        #region Properties

        public IContactsDbContext DbContext { get; private set; }

        public DbSet<TEntity> Table { get; private set; }

        #endregion

        #region Constructor

        public BaseRepository(IContactsDbContext dbContext)
        {
            DbContext = dbContext;
            Table = DbContext.Set<TEntity>();
        }

        #endregion

        #region Ins

        public async Task<TEntity> Ins(TEntity entity)
        {
            var @new = await Table.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return @new.Entity;
        }

        #endregion

        #region Del

        public async Task Del(TEntity entity)
        {
            Table.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Del(int id)
        {
            Table.Remove(Table.Where(x => x.Id == id).First());
            await DbContext.SaveChangesAsync();
        }

        public async Task Del(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new NullPredicateException();
            var entities = await GetMany(predicate);
            if (entities.Any())
            {
                DbContext.RemoveRange(entities);
                await DbContext.SaveChangesAsync();
            }
        }

        #endregion

        #region Upd

        public async Task Upd(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        #endregion

        #region Get, GetAll, GetMany, Exist

        public virtual async Task<TEntity?> Get(int id) => await Table.Where(x => x.Id == id).FirstOrDefaultAsync();

        public virtual async Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new NullPredicateException();
            return await Table.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task<IList<TEntity>> GetAll() => await Table.ToListAsync();

        public virtual async Task<IList<TEntity>> GetMany(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new NullPredicateException();
            return await Table.Where(predicate).ToListAsync();
        }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new NullPredicateException();
            return await Table.Where(predicate).AnyAsync();
        }

        public virtual async Task<TEntity?> GetAsNoTracking(int id) => await Table.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

        public virtual async Task<TEntity?> GetAsNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new NullPredicateException();
            return await Table.Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual async Task<IList<TEntity>> GetAllAsNoTracking() => await Table.AsNoTracking().ToListAsync();

        public virtual async Task<IList<TEntity>> GetManyAsNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new NullPredicateException();
            return await Table.Where(predicate).AsNoTracking().ToListAsync();
        }

        public virtual async Task<TDto?> Get<TDto>(int id, Expression<Func<TEntity, TDto>> select) => await Table.Where(x => x.Id == id).AsNoTracking().Select(select).FirstOrDefaultAsync();

        public virtual async Task<TDto?> Get<TDto>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TDto>> select)
        {
            if (predicate == null)
                throw new NullPredicateException();
            return await Table.Where(predicate).AsNoTracking().Select(select).FirstOrDefaultAsync();
        }

        public virtual async Task<IList<TDto>> GetAll<TDto>(Expression<Func<TEntity, TDto>> select) => await Table.AsNoTracking().Select(select).ToListAsync();

        public virtual async Task<IList<TDto>> GetMany<TDto>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TDto>> select)
        {
            if (predicate == null)
                throw new NullPredicateException();
            return await Table.Where(predicate).AsNoTracking().Select(select).ToListAsync();
        }

        #endregion
    }
}
