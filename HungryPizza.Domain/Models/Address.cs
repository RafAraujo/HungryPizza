using HungryPizza.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace HungryPizza.Domain.Models
{
    public class Address : Entity
    {
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ZipCode { get; set; }
    }
}
