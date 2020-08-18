using HungryPizza.Domain.Models.Base;

namespace HungryPizza.Domain.Models
{
    public class CustomerAddress : Entity
    {
        public int CustomerId { get; set; }

        public int AddressId { get; set; }
    }
}
