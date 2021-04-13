using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models
{
    public class ThingContext : DbContext
    {
        public ThingContext(DbContextOptions<ThingContext> options) : base(options) { }

        public DbSet<Thing> Things { get; set; }
    }
}
