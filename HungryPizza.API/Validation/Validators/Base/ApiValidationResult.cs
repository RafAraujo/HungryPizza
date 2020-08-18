using FluentValidation.Results;
using HungryPizza.API.Validation.Validators.Intefaces;
using System.Collections.Generic;
using System.Linq;

namespace HungryPizza.API.Validation.Validators.Base
{
    public class ApiValidationResult : IApiValidationResult
    {
        private readonly ValidationResult _validationResult;

        public ApiValidationResult(ValidationResult validationResult)
        {
            _validationResult = validationResult;
        }

        public bool IsValid
        {
            get => _validationResult.IsValid;
        }

        public IEnumerable<string> Errors
        {
            get => _validationResult.Errors.Select(e => e.ErrorMessage);
        }
    }
}
