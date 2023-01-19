namespace EightFigures.Contacts.Domain.CustomException.Business
{
    public class ExistingLogInException: BaseBusinessException
    {
        public ExistingLogInException(string logIn) : base($"LogIn [{logIn}] already exists") { }
    }
}
