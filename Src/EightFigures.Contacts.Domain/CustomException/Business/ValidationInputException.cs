namespace EightFigures.Contacts.Domain.CustomException.Business
{
    public class ValidationInputException: BaseBusinessException
    {
        public ValidationInputException(string errors): base(errors) { }
    }
}
