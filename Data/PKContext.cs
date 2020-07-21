using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class PKContext : IdentityDbContext<PKUser>
    {
        public PKContext(DbContextOptions<PKContext> options) : base(options)
        {

        }
        public DbSet<CoreService> CoreServices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoreService>().HasMany(c => c.Services)
                .WithOne(s => s.CoreService);
            base.OnModelCreating(modelBuilder);
        }
    }
}
