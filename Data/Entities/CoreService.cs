using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data.Entities
{
    public class CoreService
    {
        public CoreService()
        {
            Services = new List<Service>();
        }
        public int Id { get; set; }
        public string CoreServiceTitle { get; set; }
        public string CoreServiceDescription { get; set; }
        public string Photo { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
