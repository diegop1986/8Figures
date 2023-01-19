namespace EightFigures.Contacts.Domain.CustomException.Internal
{
    public class NullPredicateException : BaseInternalException
    {
        public NullPredicateException() : base("Predicate must be not null") { }
    }
}
