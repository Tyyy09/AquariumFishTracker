using Microsoft.EntityFrameworkCore;
using AquariumFishTracker.Models;

namespace AquariumFishTracker.Data
{
    public class AquariumContext : DbContext
    {
        public AquariumContext(DbContextOptions<AquariumContext> options)
            : base(options)
        {
        }

        public DbSet<Fish> Fish { get; set; }
        public DbSet<Tank> Tanks { get; set; }
    }
}
