using FluentValidation;
using EightFigures.Contacts.Service.Dto;

namespace EightFigures.Contacts.Service.Validation
{
    public class ContactDelDtoValidation : BaseValidator<ContactDelDto>
    {
        public ContactDelDtoValidation() : base()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage(GreaterThanZeroMessage);
        }
    }
}