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
        public DateTime OrderDate { get; set; }
        public ICollection<OrderService> Services { get; set; }
        public string OrderNumber { get; set; }
        public PKUser PKUser { get; set; }
    }
}
