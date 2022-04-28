using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DroneAPI.Model
{
    public class DroneDbContext : DbContext
    {
        public DroneDbContext(DbContextOptions<DroneDbContext> options) : base(options)
        {
        }

        public DbSet<Drone> Drones { get; set; }
        public DbSet<Medicine> Medicines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drone>().ToTable("Drones");
            modelBuilder.Entity<Drone>().HasKey(s => s.NumSeries);

            
            modelBuilder.Entity<Medicine>().ToTable("Medicine");

            modelBuilder.Entity<Medicine>().Property(p => p.MedicineId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Medicine>()
                .HasOne(s => s.Drone)
                .WithMany(g => g.Medicines)
                .HasForeignKey(s => s.DroneId);
        }
    }
}