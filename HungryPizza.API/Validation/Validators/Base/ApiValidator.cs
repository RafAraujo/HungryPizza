using FluentValidation;
using HungryPizza.API.Validation.Validators.Intefaces;

namespace HungryPizza.API.Validation.Validators.Base
{
    public class ApiValidator<T> : AbstractValidator<T>, IApiValidator<T>
    {
        public new IApiValidationResult Validate(T instance)
        {
            var validationResult = base.Validate(instance);

            return new ApiValidationResult(validationResult);
        }
    }
}
