using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Project.Models
{
    public class HrContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=HR;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);
            modelBuilder.Entity<Employee>()
                .HasOne<Job>(e => e.Job)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobId);
            modelBuilder.Entity<Department>()
               .HasOne<Location>(d => d.Location)
               .WithMany(l => l.Departments)
               .HasForeignKey(d => d.LocationId);
            modelBuilder.Entity<Location>()
               .HasOne<Country>(l => l.Country)
               .WithMany(c => c.Locations)
               .HasForeignKey(l => l.CountryId);
            modelBuilder.Entity<Country>()
               .HasOne<Region>(c => c.Region)
               .WithMany(r => r.Countries)
               .HasForeignKey(c => c.RegionId);
            modelBuilder.Entity<JobHistory>().HasKey(jh => new { jh.DepartmentId,jh.EmployeeId,jh.JobId });
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<JobGrade> JobGrades { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<JobHistory> JobHistory { get; set; }
    }
}