using HungryPizza.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace HungryPizza.Domain.Models
{
    public class Category : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
