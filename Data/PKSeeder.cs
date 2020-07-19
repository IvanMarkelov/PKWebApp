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
            if(!_context.CoreServices.Any())
            {
                // Create sample data
                string path = Path.Combine(_hosting.ContentRootPath, "Data/core_services.json");
                var json = File.ReadAllText(path); 
                  var coreServices = JsonConvert.DeserializeObject<IEnumerable<CoreService>>(json);
                _context.CoreServices.AddRange(coreServices);
                _context.SaveChanges();
            }
             
            if (!_context.Services.Any())
            {
                // Create sample data
                string path = Path.Combine(_hosting.ContentRootPath, "Data/services.json");
                var json = File.ReadAllText(path);
                var services = JsonConvert.DeserializeObject<IEnumerable<Service>>(json);
                _context.Services.AddRange(services);
                _context.SaveChanges();
            }

            if (!_context.Tickets.Any())
            {
                var ticket1 = new Ticket { Location = "Dubai",
                    CalculatedPrice = 50000
                };
                _context.Add(ticket1);
                _context.SaveChanges();
            }    
        }
    }
}
