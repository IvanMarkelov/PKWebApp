using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data.Entities
{
    public class OrderService
    {
        public int Id { get; set; }
        public Service Service { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
    }
}
