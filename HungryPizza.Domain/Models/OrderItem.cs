using HungryPizza.Domain.Models.Base;

namespace HungryPizza.Domain.Models
{
    public class OrderItem : Entity
    {
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal CalculatePrice() => Price = UnitPrice * Quantity;
    }
}
