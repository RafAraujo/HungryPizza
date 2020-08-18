using System.Collections.Generic;

namespace HungryPizza.API.Validation.Validators.Intefaces
{
    public interface IApiValidationResult
    {
        public bool IsValid { get; }

        public IEnumerable<string> Errors { get; }
    }
}
