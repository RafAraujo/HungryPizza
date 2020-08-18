using HungryPizza.Domain.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HungryPizza.Domain.Models
{
    public class Customer : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string IdentityDocument { get; set; }

        public virtual List<Address> Addresses { get; set; } = new List<Address>();
    }
}
