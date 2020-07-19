using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data.Entities
{
    public class Ticket
    {
        public Ticket()
        {
            ServicesRequested = new List<Service>();
        }
        public int Id { get; set; }
        public List<Service> ServicesRequested { get; set; }
        public string Location { get; set; }
        public int EstimatedBudget { get; set; }
        public int CalculatedPrice { get; set; }
        public ClientContactInfo ClientContactInfo { get; set; }
    }
}
