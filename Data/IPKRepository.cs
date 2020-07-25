using PKWebApp.Data.Entities;
using System.Collections.Generic;

namespace PKWebApp.Data
{
    public interface IPKRepository
    {
        IEnumerable<CoreService> GetAllCoreServices();
        IEnumerable<CoreService> GetCoreServicesByDescription(string queryPart);
        bool SaveChanges();
        IEnumerable<Order> GetAllTickets();
        Order GetTicketById(int id);
        void AddEntity(object model);
        IEnumerable<Service> GetServicesByCoreServiceId(int coreServiceId);
        IEnumerable<Service> GetAllServices();
    }
}