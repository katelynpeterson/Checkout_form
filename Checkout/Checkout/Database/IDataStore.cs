using System;
using System.Collections.Generic;
using System.Text;
using Checkout.VMs.Entity;

namespace Checkout.Data
{
    public interface IDataStore
    {
        void AddCustomer(Customer c);
        void PurchaseProduct(Product p);
        IEnumerable<Customer> GetAllCustomers();
    }
}
