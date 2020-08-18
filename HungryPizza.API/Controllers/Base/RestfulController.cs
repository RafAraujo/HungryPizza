using HungryPizza.API.DTO;
using HungryPizza.API.Validation.Validators.Intefaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace HungryPizza.API.Controllers.Base
{
    public class RestfulController : ControllerBase
    {
        protected HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;

        protected ApiResponseDto ApiResponse { get; set; } = new ApiResponseDto();

        public bool Validate<T>(IApiValidator<T> validator, T instance)
        {
            var validationResult = validator.Validate(instance);

            if (!validationResult.IsValid)
            {
                HttpStatusCode = HttpStatusCode.BadRequest;
                ApiResponse.Success = false;
                ApiResponse.Messages = validationResult.Errors.ToList();
            }

            return validationResult.IsValid;
        }
    }
}
