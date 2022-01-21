
using FictionalProgrammers.Models;
using Microsoft.EntityFrameworkCore;

namespace FictionalProgrammers.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Progr_Project>()
        //        .HasOne(p => p.Project)
        //        .WithMany(pp => pp.Progr_Projects)
        //        .HasForeignKey(pi => pi.ProjectId);

        //    modelBuilder.Entity<Progr_Project>()
        //        .HasOne(p => p.Programmer)
        //        .WithMany(pp => pp.Progr_Projects)
        //        .HasForeignKey(pi => pi.ProgrammerId);

        //}
        public DbSet<Project> Project { get; set; }

        public DbSet<Programmer> Programmer { get; set; }

        
    }
}
