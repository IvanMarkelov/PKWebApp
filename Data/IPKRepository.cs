using PKWebApp.Data.Entities;
using System.Collections.Generic;

namespace PKWebApp.Data
{
    public interface IPKRepository
    {
        IEnumerable<CoreService> GetAllCoreServices();
        IEnumerable<CoreService> GetCoreServicesByDescription(string queryPart);
        bool SaveChanges();
        IEnumerable<Ticket> GetAllTickets();
    }
}