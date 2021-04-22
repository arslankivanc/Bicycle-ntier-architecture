using Bicycle.DataAccess.Identity;
using Bicycle.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bicycle.DataAccess.Contexts
{
    public class DatabaseContext:IdentityDbContext<AppUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
        }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<RentBicycle> RentBicycles { get; set; }
        public DbSet<BicycleStockOnHold> BicycleStockOnHolds { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
