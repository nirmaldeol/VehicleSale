using carvecho.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace carvecho.Persistence
{
    public class CarVechoDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehical> Vehicals { get; set; }
        
        public CarVechoDbContext(DbContextOptions<CarVechoDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicalFeature>().HasKey(vf => new { vf.VehicalId, vf.FeatureId });
        }

    }
}