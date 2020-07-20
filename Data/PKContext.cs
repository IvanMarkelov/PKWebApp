using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PKWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Data
{
    public class PKContext : DbContext
    {
        public PKContext(DbContextOptions<PKContext> options) : base(options)
        {

        }
        public DbSet<CoreService> CoreServices { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ClientContactInfo> ClientContacts { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoreService>().HasMany(c => c.Services)
                .WithOne(s => s.CoreService);
        }
    }
}
