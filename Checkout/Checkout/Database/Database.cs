using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Checkout.VMs.Entity;
using Checkout.VMs.DomainPrimatives;

namespace Checkout.Data
{
    public class Database: IDataStore
    {
        private readonly CheckoutContext context;
        private readonly string dbPath;

        public Database(string dbPath)
        {
            this.dbPath = dbPath ?? throw new ArgumentNullException(nameof(dbPath));
            context = new CheckoutContext(dbPath);
        }

        public void AddCustomer(Customer c)
        {
            context.Customers.Add(c);
            context.SaveChanges();
        }

        public void PurchaseProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return context.Customers;
        }

       public void AddLog(Log l)
        {
            context.Log.Add(l);
            context.SaveChanges();
        }

        public void AddOrder(Order o)
        {
            context.Orders.Add(o);
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
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite($@"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>()
                //.HasKey(c => c.Id);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
