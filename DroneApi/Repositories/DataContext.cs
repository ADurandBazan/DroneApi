using DroneApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DroneApi.Repositories
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // in memory database used for simplicity, change to a real db for production applications
            options.UseInMemoryDatabase("DroneDb");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Medication>()
           .HasOne(p => p.Drone)
           .WithMany(b => b.Medications)
           .HasForeignKey(p => p.DroneId)
           .OnDelete(DeleteBehavior.Cascade);




        }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Medication> Medications { get; set; }
      
    }
}

