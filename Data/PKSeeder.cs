using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<PKUser> _userManager;

        public PKSeeder(PKContext context, 
            IWebHostEnvironment hosting, 
            UserManager<PKUser> userManager)
        {
            _context = context;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            PKUser user = await _userManager.FindByEmailAsync("test@mail.com");
            if (user == null)
            {
                user = new PKUser()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "test@mail.com",
                    UserName = "test@mail.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssW0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not creat new user in seeder");
                }
            }
            if (!_context.CoreServices.Any())
            {
                // Create sample data
                string path = Path.Combine(_hosting.ContentRootPath, "Data/core_services.json");
                var json = File.ReadAllText(path);
                var coreServices = JsonConvert.DeserializeObject<IEnumerable<CoreService>>(json);
                _context.CoreServices.AddRange(coreServices);
                _context.SaveChanges();
            }

            if (!_context.Orders.Any())
            {
                var order = new Order
                {
                    OrderDate = DateTime.Now
                };
                order.PKUser = user;
                order.Services = new List<OrderService>()
                {
                    new OrderService()
                    {
                        Service = _context.Services.First(),
                        Price = _context.Services.First().ServicePriceTag
                    }
                };
                _context.Add(order);
                _context.SaveChanges();
            }
        }
    }
}
