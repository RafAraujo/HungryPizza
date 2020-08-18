using System.Collections.Generic;

namespace HungryPizza.API.DTO.Order
{
    public class OrderRequestDto
    {
        public CustomerRequestDto Customer { get; set; }

        public List<OrderItemRequestDto> Items { get; set; }
    }

    public class CustomerRequestDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string IdentityDocument { get; set; }

        public AddressRequestDto Address { get; set; }
    }

    public class AddressRequestDto
    {
        public int? Id { get; set; }

        public string Description { get; set; }

        public string ZipCode { get; set; }
    }

    public class OrderItemRequestDto
    {
        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
