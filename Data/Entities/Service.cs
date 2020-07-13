using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsAvailable { get; set; }
        public string Photo { get; set; }
    }
}
