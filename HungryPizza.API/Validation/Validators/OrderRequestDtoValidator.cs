using FluentValidation;
using HungryPizza.API.DTO.Order;
using HungryPizza.API.Validation.Validators.Base;
using HungryPizza.API.Validation.Validators.Intefaces;

namespace HungryPizza.API.Validation.Validators
{
    public class OrderRequestDtoValidator : ApiValidator<OrderRequestDto>, IApiValidator<OrderRequestDto>
    {
        private readonly IApiValidator<CustomerRequestDto> _customerRequestDtoValidator;
        private readonly IApiValidator<OrderItemRequestDto> _orderItemRequestDtoValidator;

        public OrderRequestDtoValidator(
            IApiValidator<CustomerRequestDto> customerRequestDtoValidator,
            IApiValidator<OrderItemRequestDto> orderItemRequestDtoValidator)
        {
            _customerRequestDtoValidator = customerRequestDtoValidator;
            _orderItemRequestDtoValidator = orderItemRequestDtoValidator;

            RuleFor(o => o.Customer)
                .NotNull()
                .SetValidator((IValidator<CustomerRequestDto>)_customerRequestDtoValidator);

            RuleFor(o => o.Items)
                .NotNull();

            RuleForEach(o => o.Items)
                .SetValidator((IValidator<OrderItemRequestDto>)_orderItemRequestDtoValidator);
        }
    }

    public class CustomerRequestDtoValidator : ApiValidator<CustomerRequestDto>, IApiValidator<CustomerRequestDto>
    {
        public CustomerRequestDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().When(c => c.Id.HasValue)
                .NotEmpty().When(c => c.Id.HasValue);

            RuleFor(c => c.IdentityDocument)
                .NotNull().When(c => c.Id.HasValue)
                .NotEmpty().When(c => c.Id.HasValue);

            RuleFor(c => c.Address)
                .NotNull().When(c => c.Id.HasValue)
                .NotEmpty().When(c => c.Id.HasValue);
        }
    }

    public class AddressRequestDtoValidator : ApiValidator<AddressRequestDto>, IApiValidator<AddressRequestDto>
    {
        public AddressRequestDtoValidator()
        {
            RuleFor(a => a.Description)
                .NotNull().When(a => a.Id.HasValue)
                .NotEmpty().When(a => a.Id.HasValue);

            RuleFor(a => a.ZipCode)
                .NotNull().When(a => a.Id.HasValue)
                .NotEmpty().When(a => a.Id.HasValue);
        }
    }

    public class OrderItemRequestDtoValidator : ApiValidator<OrderItemRequestDto>, IApiValidator<OrderItemRequestDto>
    {
        public OrderItemRequestDtoValidator()
        {
            RuleFor(oi => oi.ProductId)
                .NotEmpty();

            RuleFor(oi => oi.Quantity)
                .NotEmpty();

            RuleFor(oi => oi.UnitPrice)
                .NotEmpty();
        }
    }
}
