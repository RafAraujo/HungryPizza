using HungryPizza.Domain.Models.Base;
using HungryPizza.Domain.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HungryPizza.Domain.Models
{
    public class Pizza : Entity, IProduct
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual List<Flavor> Flavors { get; set; } = new List<Flavor>();

        public string GetName()
        {
            return Flavors.Count switch
            {
                1 => string.Format("Pizza {0}", Flavors.First().Name),
                2 => string.Format("Pizza {0} + {1}", Flavors.First().Name, Flavors.Last().Name),
                _ => string.Empty,
            };
        }

        public decimal CalculatePrice() => Flavors.Sum(f => f.Price);
    }
}
