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

        public void AddEntity(object model)
        {
            _context.Add(model);
        }

        public IEnumerable<CoreService> GetAllCoreServices()
        {
            return _context.CoreServices
                .OrderBy(s => s.CoreServiceTitle)
                .ToList();
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _context.Tickets
                .Include(o => o.Service)
                .Include(o => o.ClientContactInfo)
                .ToList();
        }

        public IEnumerable<CoreService> GetCoreServicesByDescription(string queryPart)
        {
            return _context.CoreServices
                .Where(d => EF.Functions.Like(d.CoreServiceDescription, "%" + queryPart + "%"))
                .ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return _context.Tickets
                .Include(o => o.Service)
                .Include(o => o.ClientContactInfo)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
