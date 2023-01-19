using Microsoft.EntityFrameworkCore;
using EightFigures.Contacts.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EightFigures.Contacts.Persistence.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.LogIn).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
