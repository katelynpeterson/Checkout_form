using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Checkout.VMs.Entity;
using Checkout.VMs.DomainPrimatives;
using Checkout.Model;
using Checkout.Database;
using Checkout.Database.DTO;
using System.Linq;

namespace Checkout.Data
{
    public class Database: IDtoStore
    {
        private readonly CheckoutContext context;
        private readonly string dbPath;

        public Database(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            context = new CheckoutContext(dbPath);
        }

        public void AddMeToDb(MyName myName)
        {
            context.MyName.Add(myName);
            context.SaveChangesAsync();
        }

        public void AddProduct(ProductDTO p)
        {
            context.Products.Add(p);
            context.SaveChangesAsync();
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return context.Products;
        }

        public void AddCustomer(CustomerDTO c)
        {
            context.Customers.Add(c);
            context.SaveChangesAsync();
        }

        public void UpdateCustomer(CustomerDTO c)
        {
            context.Update(c);
            context.SaveChangesAsync();
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return context.Customers;
        }

        public IEnumerable<CustomerDTO> GetCustomerByEmail(string email)
        {
            return context.Customers.Where(x=>x.EmailAddress.Equals(email));
            
        }


        //    public void PurchaseProduct(Product p)
        //    {
        //        context.Products.Add(p);
        //        context.SaveChanges();
        //    }


        public void AddLog(LogDTO l)
        {
            context.Log.Add(l);
            context.SaveChanges();
        }

    }

    class CheckoutContext : DbContext
    {
        private readonly string dbPath;
        private static bool _created = false;

        public CheckoutContext(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite($@"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyName>()
                .HasKey(c => c.Name);
            modelBuilder.Entity<ProductDTO>().HasKey(p => p.Id);
            modelBuilder.Entity<CustomerDTO>().HasKey(c => c.Id);
            modelBuilder.Entity<LogDTO>().HasKey(l => l.DateStamp);
        }

        public DbSet<CustomerDTO> Customers { get; set; }
        public DbSet<ProductDTO> Products { get; set; }
        public DbSet<MyName> MyName { get; set; }
        public DbSet<LogDTO> Log { get; set; }
        //public DbSet<Order> Orders { get; set; }
    }
}
