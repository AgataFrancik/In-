using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class AnimalsDbContext : DbContext
    {
        private string _connectionString = "Server=DESKTOP-JHA0BD8\\FRANCIKPROJ;Database=AnimalsDb;Trusted_Connection=True;";
        public DbSet<Animal> Animals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Specie> Species { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(r => r.Login)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<User>()
                .Property(r => r.Password)
                .IsRequired();

            modelBuilder.Entity<Specie>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Animal>()
                .HasOne<Specie>(e => e.Specie)
                .WithMany(g => g.Animal)
                .HasForeignKey(s => s.SpecieId);

            modelBuilder.Entity<Animal>()
                .HasOne<User>(e => e.User)
                .WithMany(g => g.Animal)
                .HasForeignKey(s => s.UserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
