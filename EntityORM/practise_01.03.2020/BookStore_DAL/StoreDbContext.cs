using BookStore_DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore_DAL
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Car> cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=CarStoreDB;Trusted_Connection=True;");
        }
    }
}
