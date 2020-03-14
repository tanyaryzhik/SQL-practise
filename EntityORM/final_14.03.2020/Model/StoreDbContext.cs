using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;

namespace Model
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Database=StoresDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .HasKey(st => new { st.StoreId, st.ProductId });
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            //Staffs table.
            modelBuilder.Entity<Staff>()
                .ToTable("staffs", "sales");
            modelBuilder.Entity<Staff>()
                .Property(s => s.Id)
                .HasColumnName("staff_id");
            modelBuilder.Entity<Staff>()
                .Property(s => s.FirstName)
                .HasColumnName("first_name");
            modelBuilder.Entity<Staff>()
                .Property(s => s.LastName)
                .HasColumnName("last_name");
            modelBuilder.Entity<Staff>()
                .Property(s => s.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Staff>()
                .Property(s => s.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Staff>()
                .Property(s => s.Active)
                .HasColumnName("active");
            modelBuilder.Entity<Staff>()
                .Property(s => s.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Staff>()
                .Property(s => s.ManagerId)
                .HasColumnName("manager_id");
            //Orders table.
            modelBuilder.Entity<Order>()
                .ToTable("orders", "sales");
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Store)
                    .WithMany(s => s.Orders)
                    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Order>()
                .Property(o => o.Id)
                .HasColumnName("order_id");
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerId)
                .HasColumnName("customer_id");
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderStatus)
                .HasColumnName("order_status");
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .HasColumnName("order_date");
            modelBuilder.Entity<Order>()
                .Property(o => o.RequiredDate)
                .HasColumnName("required_date");
            modelBuilder.Entity<Order>()
                .Property(o => o.ShippedDate)
                .HasColumnName("shipped_date");
            modelBuilder.Entity<Order>()
                .Property(o => o.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Order>()
                .Property(o => o.StaffId)
                .HasColumnName("staff_id");
            //Orderitems table.
            modelBuilder.Entity<OrderItem>()
                .ToTable("order_items", "sales");
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.OrderId)
                .HasColumnName("order_id");
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Quantity)
                .HasColumnName("quantity");
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Price)
                .HasColumnName("list_price");
            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Discount)
                .HasColumnName("discount");
            //Stores table.
            modelBuilder.Entity<Store>()
                .ToTable("stores", "sales");
            modelBuilder.Entity<Store>()
                .Property(s => s.Id)
                .HasColumnName("store_id");
            modelBuilder.Entity<Store>()
                .Property(s => s.StoretName)
                .HasColumnName("store_name");
            modelBuilder.Entity<Store>()
                .Property(s => s.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Store>()
                .Property(s => s.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Store>()
                .Property(s => s.Street)
                .HasColumnName("street");
            modelBuilder.Entity<Store>()
                .Property(s => s.City)
                .HasColumnName("city");
            modelBuilder.Entity<Store>()
                .Property(s => s.State)
                .HasColumnName("state");
            modelBuilder.Entity<Store>()
                .Property(s => s.ZipCode)
                .HasColumnName("zip_code");
            //Customers table.
            modelBuilder.Entity<Customer>()
                .ToTable("customers", "sales");
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .HasColumnName("customer_id");
            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .HasColumnName("first_name");
            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName)
                .HasColumnName("last_name");
            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .HasColumnName("email");
            modelBuilder.Entity<Customer>()
                .Property(c => c.Phone)
                .HasColumnName("phone");
            modelBuilder.Entity<Customer>()
                .Property(c => c.Street)
                .HasColumnName("street");
            modelBuilder.Entity<Customer>()
                .Property(c => c.City)
                .HasColumnName("city");
            modelBuilder.Entity<Customer>()
                .Property(c => c.State)
                .HasColumnName("state");
            modelBuilder.Entity<Customer>()
                .Property(c => c.ZipCode)
                .HasColumnName("zip_code");
            //Products table.
            modelBuilder.Entity<Product>()
                .ToTable("products", "production");
            modelBuilder.Entity<Product>()
                .Property(p => p.Id).HasColumnName("product_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasColumnName("product_name");
            modelBuilder.Entity<Product>()
                .Property(p => p.BrandId)
                .HasColumnName("brand_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.CategoryId)
                .HasColumnName("category_id");
            modelBuilder.Entity<Product>()
                .Property(p => p.ModelYear)
                .HasColumnName("model_year");
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnName("list_price");
            //Stocks table.
            modelBuilder.Entity<Stock>()
                .ToTable("stocks", "production");
            modelBuilder.Entity<Stock>()
                .Property(p => p.StoreId)
                .HasColumnName("store_id");
            modelBuilder.Entity<Stock>()
                .Property(p => p.ProductId)
                .HasColumnName("product_id");
            modelBuilder.Entity<Stock>()
                .Property(p => p.Quantity)
                .HasColumnName("quantity");
            //Brands table.
            modelBuilder.Entity<Brand>()
                .ToTable("brands", "production");
            modelBuilder.Entity<Brand>()
                .Property(p => p.Id)
                .HasColumnName("brand_id");
            modelBuilder.Entity<Brand>()
                .Property(p => p.Name)
                .HasColumnName("brand_name");
            //Categories table.
            modelBuilder.Entity<Category>()
                .ToTable("categories", "production");
            modelBuilder.Entity<Category>()
                .Property(p => p.Id)
                .HasColumnName("category_id");
            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .HasColumnName("category_name");
            //DataSeeding.
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "BrandFirst"
                },
                new Brand
                {
                    Id = 2,
                    Name = "BrandSecond"
                });
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 3,
                    Name = "CategoryFirst"
                },
                new Category
                {
                    Id = 4,
                    Name = "CategorySecond"
                });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 5,
                    Name = "ProductFirst",
                    BrandId = 1,
                    CategoryId = 3,
                    ModelYear = 2000,
                    Price = 200.50m
                },
                new Product
                {
                    Id = 6,
                    Name = "ProductSecond",
                    BrandId = 2,
                    CategoryId = 4,
                    ModelYear = 2010,
                    Price = 400.50m
                });
            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    Id = 7,
                    StoretName = "StoreFirst",
                    Phone = "12345",
                    Email = "firststore@gmail.com",
                    Street = "1st Ave",
                    City = "New York",
                    State = "WashingtonDC",
                    ZipCode = 25364
                },
                new Store
                {
                    Id = 8,
                    StoretName = "StoreSecond",
                    Phone = "678910",
                    Email = "secondstore@gmail.com",
                    Street = "2nd Ave",
                    City = "Dallas",
                    State = "Texas",
                    ZipCode = 52147
                });
            modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                    StoreId = 7,
                    ProductId = 6,
                    Quantity = 5
                },
                new Stock
                {
                    StoreId = 8,
                    ProductId = 5,
                    Quantity = 10
                });
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 9,
                    FirstName = "Allan",
                    LastName = "Pau",
                    Phone = "54698",
                    Email = "allanpau@gmail.com",
                    Street = "3rd St",
                    City = "Akron",
                    State = "Ohio",
                    ZipCode = 25641
                },
                new Customer
                {
                    Id = 10,
                    FirstName = "Katy",
                    LastName = "Perry",
                    Phone = "25489",
                    Email = "katyperry@gmail.com",
                    Street = "4th St",
                    City = "Los Angeles",
                    State = "California",
                    ZipCode = 26543
                });
            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 11,
                    FirstName = "Jim",
                    LastName = "Kerry",
                    Phone = "2598",
                    Email = "jimkerry@gmail.com",
                    Active = true,
                    StoreId = 7,
                    ManagerId = 12
                },
                new Staff
                {
                    Id = 12,
                    FirstName = "Katy",
                    LastName = "lerry",
                    Phone = "3654",
                    Email = "katylerry@gmail.com",
                    Active = true,
                    StoreId = 8,
                });
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 13,
                    CustomerId = 10,
                    OrderStatus = "Pending",
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    StoreId = 7,
                    StaffId = 12
                },
                new Order
                {
                    Id = 14,
                    CustomerId = 9,
                    OrderStatus = "Pending",
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now,
                    ShippedDate = DateTime.Now,
                    StoreId = 8,
                    StaffId = 11
                });
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    OrderId = 13,
                    ProductId = 5,
                    Quantity = 1,
                    Price = 52m,
                    Discount = 0
                },
                 new OrderItem
                 {
                     OrderId = 14,
                     ProductId = 6,
                     Quantity = 1,
                     Price = 100m,
                     Discount = 0
                 });
        }
    }
}