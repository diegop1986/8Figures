namespace EightFigures.Contacts.Domain.CustomException.NotFound
{
    public class ContactNotFoundException : BaseNotFoundException
    {
        public ContactNotFoundException() : base("Contact not found") { }
    }
}