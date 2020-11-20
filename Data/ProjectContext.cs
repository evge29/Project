using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<Coaches> Coaches { get; set; }

        public DbSet<Programs> Programs { get; set; }

        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<ClientProgram> ClientProgram { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasOne<Clients>(p => p.Client)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(p => p.ClientId);


            modelBuilder.Entity<Enrollment>()
                .HasOne<Programs>(d => d.Program)
                .WithMany(d => d.Enrollments)
                .HasForeignKey(d => d.ProgramId);

            modelBuilder.Entity<Programs>()
                .HasOne<Coaches>(p => p.Coach)
                .WithMany(p => p.Programs)
                .HasForeignKey(p => p.CoachId);

        }

    }
}
