using HungryPizza.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace HungryPizza.Domain.Models
{
    public class Flavor : Entity
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
