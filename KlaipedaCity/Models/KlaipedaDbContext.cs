using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KlaipedaCity.Models
{
    public class KlaipedaDbContext : IdentityDbContext
    {
        public KlaipedaDbContext(
            DbContextOptions<KlaipedaDbContext> options) : base(options) { }

        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
