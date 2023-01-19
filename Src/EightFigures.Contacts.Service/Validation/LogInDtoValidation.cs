using FluentValidation;
using EightFigures.Contacts.Service.Dto;

namespace EightFigures.Contacts.Service.Validation
{
    public class LogInDtoValidation : BaseValidator<LogInDto>
    {
        public LogInDtoValidation() : base()
        {
            RuleFor(p => p.LogIn).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.Password).NotEmpty().WithMessage(RequiredMessage);
        }
    }
}
