using FluentValidation;
using EightFigures.Contacts.Service.Dto;

namespace EightFigures.Contacts.Service.Validation
{
    public class UserAddDtoValidation : BaseValidator<UserAddDto>
    {
        public UserAddDtoValidation() : base()
        {
            RuleFor(p => p.LogIn).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.Password).NotEmpty().WithMessage(RequiredMessage);
            RuleFor(p => p.Name).NotEmpty().WithMessage(RequiredMessage);
        }
    }
}
