using AutoMapper;
using HungryPizza.API.Controllers.Base;
using HungryPizza.API.DTO;
using HungryPizza.API.DTO.Order;
using HungryPizza.API.Validation.Validators.Intefaces;
using HungryPizza.Application.Services.Interfaces;
using HungryPizza.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HungryPizza.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : RestfulController
    {
        private readonly IApiValidator<OrderRequestDto> _orderRequestDtoValidator;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public OrderController(
            IApiValidator<OrderRequestDto> orderRquestDtoValidator,
            IMapper mapper,
            ICustomerService customerService,
            IOrderService orderService)
        {
            _orderRequestDtoValidator = orderRquestDtoValidator;
            _mapper = mapper;
            _customerService = customerService;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponseDto>> CreateOrderAsync(OrderRequestDto request)
        {
            if (Validate(_orderRequestDtoValidator, request))
            {
                var order = _mapper.Map<Order>(request);

                await _customerService.CreateIfNotExistsAsync(order.Customer);

                ApiResponse.Result = await _orderService.CreateOrderAsync(order);
            }

            return StatusCode((int)HttpStatusCode, ApiResponse);
        }
    }
}
