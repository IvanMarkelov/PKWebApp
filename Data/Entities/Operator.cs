using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data.Entities
{
    public class Operator
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public bool IsActive { get; set; }
        public string Rank { get; set; }
        public int StartedIn { get; set; }
        public string Photo { get; set; }
    }
}
