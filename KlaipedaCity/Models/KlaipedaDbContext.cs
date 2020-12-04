using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KlaipedaCity.Models
{
    public class KlaipedaDbContext : DbContext
    {
        public KlaipedaDbContext(
            DbContextOptions<KlaipedaDbContext> options) : base(options) { }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
