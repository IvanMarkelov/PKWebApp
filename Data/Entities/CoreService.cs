using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data.Entities
{
    public class CoreService
    {
        public int Id { get; set; }
        public string CoreServiceTitle { get; set; }
        public string CoreServicDescription { get; set; }
        public string Photo { get; set; }
        public List<Service> Services { get; set; }
    }
}
