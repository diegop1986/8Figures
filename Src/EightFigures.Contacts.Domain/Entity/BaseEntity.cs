using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EightFigures.Contacts.Domain.Entity
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public string UserCreated { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public string? UserUpdated { get; set; }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is BaseEntity)
                return ((BaseEntity)obj).Id == Id;
            return false;
        }

        public override int GetHashCode() => HashCode.Combine(Id);

        public static bool operator ==(BaseEntity obj1, BaseEntity obj2) => obj1?.Id == obj2?.Id;

        public static bool operator !=(BaseEntity obj1, BaseEntity obj2) => obj1?.Id != obj2?.Id;
    }
}
