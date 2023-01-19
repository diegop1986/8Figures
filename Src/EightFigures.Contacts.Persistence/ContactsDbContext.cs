using Microsoft.EntityFrameworkCore;
using EightFigures.Contacts.Domain.Entity;

namespace EightFigures.Contacts.Persistence
{
    public class ContactsDbContext: DbContext, IContactsDbContext
    {
        #region Tables

        public DbSet<User> User { get; set; }

        public DbSet<Contact> Contact { get; set; }

        #endregion

        #region Constructor

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options) { }

        #endregion

        #region Entity Framework Methods

        protected override void OnModelCreating(ModelBuilder builder) => builder.ApplyConfigurationsFromAssembly(typeof(ContactsDbContext).Assembly);

        #endregion
    }
}
