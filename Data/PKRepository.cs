using Microsoft.EntityFrameworkCore;
using PKWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data
{
    public class PKRepository : IPKRepository
    {
        private readonly PKContext _context;

        public PKRepository(PKContext context)
        {
            _context = context;
        }

        public IEnumerable<CoreService> GetAllCoreServices()
        {
            return _context.CoreServices
                .OrderBy(s => s.CoreServiceTitle)
                .ToList();
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public IEnumerable<CoreService> GetCoreServicesByDescription(string queryPart)
        {
            return _context.CoreServices
                .Where(d => EF.Functions.Like(d.CoreServicDescription, "%" + queryPart + "%"))
                .ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
