using FluentValidation;
using EightFigures.Contacts.Service.Dto;

namespace EightFigures.Contacts.Service.Validation
{
    public class ContactAddDtoValidation : BaseValidator<ContactAddDto>
    {
        public ContactAddDtoValidation() : base()
        {
            RuleFor(p => p.FullName).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.UserRequest).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.UserId).NotNull().WithMessage(RequiredMessage).GreaterThan(0).WithMessage(GreaterThanZeroMessage);
        }
    }
}
