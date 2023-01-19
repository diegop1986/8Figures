using FluentValidation;
using EightFigures.Contacts.Service.Dto;

namespace EightFigures.Contacts.Service.Validation
{
    public class ContactUpdDtoValidation : BaseValidator<ContactUpdDto>
    {
        public ContactUpdDtoValidation() : base()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage(GreaterThanZeroMessage);
            RuleFor(p => p.FullName).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.UserRequest).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.UserId).NotNull().WithMessage(RequiredMessage).GreaterThan(0).WithMessage(GreaterThanZeroMessage);
        }
    }
}
