using HungryPizza.API.Controllers.Base;
using HungryPizza.API.DTO;
using HungryPizza.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HungryPizza.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : RestfulController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("{id}/GetOrderHistory")]
        public async Task<ActionResult<ApiResponseDto>> GetOrderHistoryAsync(int id)
        {
            ApiResponse.Result = await _customerService.GetOrderHistoryAsync(id);

            return StatusCode((int)HttpStatusCode, ApiResponse);
        }
    }
}
