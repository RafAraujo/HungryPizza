using AutoMapper;
using HungryPizza.API.DTO.Order;

namespace HungryPizza.API.Mappings.Order
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<OrderRequestDto, Domain.Models.Order>();
        }
    }
}
