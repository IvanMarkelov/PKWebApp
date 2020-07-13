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
        public string Description { get; set; }
        public ICollection<CoreService> Services { get; set; }
    }
}
