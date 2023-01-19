namespace EightFigures.Contacts.Domain.Entity
{
    public class User : BaseEntity
    {
        public string LogIn { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string? Email { get; set; }

        public IList<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
