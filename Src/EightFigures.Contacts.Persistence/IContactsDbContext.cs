using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using EightFigures.Contacts.Domain.Entity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EightFigures.Contacts.Persistence
{
    public interface IContactsDbContext
    {
        #region Tables

        DbSet<User> User { get; set; }

        DbSet<Contact> Contact { get; set; }

        #endregion

        #region Properties

        public DatabaseFacade Database { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        #endregion

        #region Methods

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void RemoveRange(params object[] entities);

        EntityEntry Entry([NotNullAttribute] object entity);

        #endregion
    }
}
