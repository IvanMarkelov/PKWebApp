using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using PKWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data
{
    public class PKSeeder
    {
        private readonly PKContext _context;
        private readonly IWebHostEnvironment _hosting;

        public PKSeeder(PKContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();
            //if(!_context.CoreServices.Any())
            //{
            //    // Create sample data
            //    string path = Path.Combine(_hosting.ContentRootPath, "Data/core_services.json");
            //    var json = File.ReadAllText(path); 
            //      var coreServices = JsonConvert.DeserializeObject<IEnumerable<CoreService>>(json);
            //    _context.CoreServices.AddRange(coreServices);
            //    _context.SaveChanges();
            //}

            if (!_context.Tickets.Any() || !_context.ClientContacts.Any())
            {
                var ticket = new Ticket
                {
                    Location = "West Arlington"
                };
                var contact = new ClientContactInfo
                {
                    ClientName = "TestClient",
                    ClientEmail = "test@mail.com",
                    ClientPhoneNumber = 3333333
                };
                _context.Add(ticket);
                _context.Add(contact);
                _context.SaveChanges();
            }
    }
    }
}
