using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Database.DTO;
using Checkout.Model;
using Checkout.VMs.DomainPrimatives;
using Checkout.VMs.Entity;

namespace Checkout.Data
{
    public interface IDataStore
    {
        void AddCustomer(Customer c);
        //void AddLog(Log l);
        //void AddOrder(Order o);
        //void PurchaseProduct(Product p);
        //IEnumerable<Customer> GetAllCustomers();
        void AddProduct(Product p);

        void AddMeToDb(MyName myName);
    }
}
