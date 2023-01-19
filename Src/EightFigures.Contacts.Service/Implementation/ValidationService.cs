using FluentValidation;
using EightFigures.Contacts.Service.Dto;
using EightFigures.Contacts.Service.Interface;
using EightFigures.Contacts.Service.Validation;
using EightFigures.Contacts.Domain.CustomException.Internal;
using EightFigures.Contacts.Domain.CustomException.Business;

namespace EightFigures.Contacts.Service.Implementation
{
    public class ValidationService: IValidationService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IDictionary<Type, Type> validators;

        public ValidationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            validators = new Dictionary<Type, Type>
            {
                { typeof(ContactAddDto), typeof(ContactAddDtoValidation) },
                { typeof(ContactUpdDto), typeof(ContactUpdDtoValidation) },
                { typeof(UserAddDto), typeof(UserAddDtoValidation) },
                { typeof(LogInDto), typeof(LogInDtoValidation)},
                { typeof(ContactDelDto), typeof(ContactDelDtoValidation)}
            };
        }

        private AbstractValidator<TType> GetValidator<TType>()
        {
            var modelType = typeof(TType);
            var hasValidator = validators.ContainsKey(modelType);
            if (hasValidator == false) throw new MissingValidationException(modelType);

            var validatorType = validators[modelType];
            var validator = serviceProvider.GetService(validatorType) as AbstractValidator<TType>;
            if (validator is null) throw new MissingValidationException(modelType);
            return validator;
        }

        public void EnsureValid<TType>(TType model)
        {
            var validator = GetValidator<TType>();
            var result = validator.Validate(model);
            if (result.IsValid == false)
            {
                throw new ValidationInputException(result.ToString());
            }
        }
    }
}
