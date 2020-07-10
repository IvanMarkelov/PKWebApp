using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data.Entities
{
    public class Contractor
    {
        public int ContractorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Speciality Specialization { get; set; }
        public bool IsActive { get; set; }
        public Status Status { get; set; }
        public int StartedIn { get; set; }
    }
}
