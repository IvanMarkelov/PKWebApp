using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Models
{
    public class OrderViewModel
    {
        public int TicketId { get; set; }
        public string Location { get; set; }
        public DateTime OrderDate { get; set; }
        [MinLength(4)]
        public int OrderNumber { get; set; }
        public int ServiceId { get; set; }
    }
}
