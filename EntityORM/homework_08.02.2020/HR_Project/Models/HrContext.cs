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