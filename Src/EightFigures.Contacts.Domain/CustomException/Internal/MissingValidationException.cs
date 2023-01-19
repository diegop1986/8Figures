namespace EightFigures.Contacts.Domain.CustomException.Internal
{

    public class MissingValidationException : BaseInternalException
    {
        public MissingValidationException(Type type) : base($"Missing validator for {type} type") { }
    }
}
