using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Checkout.Database.DTO;
using Checkout.Model;
using Checkout.VMs.DomainPrimatives;
using Checkout.VMs.Entity;

namespace Checkout.Data
{
    public interface IDataStore
    {
        //void AddLog(Log l);
        //void AddOrder(Order o);
        //void PurchaseProduct(Product p);
        void AddCustomer(Customer c);
        void UpdateCustomer(Customer c);
        ObservableCollection<Customer> GetAllCustomers();
        ObservableCollection<Customer> GetCustomerByEmail(string email);
        void AddProduct(Product p);
        ObservableCollection<Product> GetAllProducts();

        void AddMeToDb(MyName myName);
    }
}
