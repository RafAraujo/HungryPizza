using HungryPizza.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace HungryPizza.Domain.Models
{
    public class Product : Entity
    {
        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public decimal Price { get; set; }
    }
}
