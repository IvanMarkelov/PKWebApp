using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public string Location { get; set; }
        public int EstimatedBudget { get; set; }
        public ClientContactInfo ClientContactInfo { get; set; }
    }
}
