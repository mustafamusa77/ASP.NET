using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customers.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PizzaType { get; set; }
        public int Quantity { get; set; }
        public string? Address { get; set; }
        public DateTime OrderDate { get; set; }

    }
}