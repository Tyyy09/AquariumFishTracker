using Microsoft.EntityFrameworkCore;
using AquariumFishTracker.Models;

namespace AquariumFishTracker.Data
{
    // DbContext for the Aquarium Fish Tracker application
    public class AquariumContext : DbContext
    {
        public AquariumContext(DbContextOptions<AquariumContext> options)
            : base(options)
        {
        }
        // DbSets for Fish and Tanks
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Tank> Tanks { get; set; }
    }
}
