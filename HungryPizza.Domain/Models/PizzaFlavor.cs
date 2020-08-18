using HungryPizza.Domain.Models.Base;

namespace HungryPizza.Domain.Models
{
    public class PizzaFlavor : Entity
    {
        public int PizzaId { get; set; }

        public int FlavorId { get; set; }
    }
}
