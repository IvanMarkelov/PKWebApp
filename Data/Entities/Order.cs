using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public Ticket Ticket { get; set; }
    }
} 
