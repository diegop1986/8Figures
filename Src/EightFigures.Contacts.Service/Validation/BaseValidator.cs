using FluentValidation;

namespace EightFigures.Contacts.Service.Validation
{
    public class BaseValidator<T> : AbstractValidator<T>
        where T : class
    {
        public string RequiredMessage => "{PropertyName} is required";

        public string GreaterThanZeroMessage => "{PropertyName} must be greater than 0";

    }
}
