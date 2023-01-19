namespace EightFigures.Contacts.Domain.Entity
{
    public class Contact : BaseEntity
    {
        public string FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
