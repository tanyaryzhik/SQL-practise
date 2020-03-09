using DAL.Model;
using Microsoft.EntityFrameworkCore;
using MvvmExample.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=StudentsDataDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
           .HasOne<Address>(s => s.Address)
           .WithOne(ad => ad.Student)
           .HasForeignKey<Address>(ad => ad.SudentId);
        }
    }
}