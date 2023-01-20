namespace EightFigures.Contacts.Domain.CustomException.Business
{
    public class ExistingEmailException : BaseBusinessException
    {
        public ExistingEmailException(string email) : base($"Email [{email}] already registered") { }
    }
}
