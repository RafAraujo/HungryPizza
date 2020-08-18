using HungryPizza.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HungryPizza.Domain.Models
{
    public class Order : Entity
    {
        public int Number { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public decimal Price { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public decimal CalculatePrice() => Price = OrderItems.Sum(p => p.Price);
    }
}