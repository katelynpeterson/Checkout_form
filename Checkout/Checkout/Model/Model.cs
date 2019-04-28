using Checkout.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkout.Model
{
    public class Model
    {

        //private ICommand purchaseCommand;
        //public ICommand PurchaseCommand => purchaseCommand ?? (purchaseCommand = new SimpleCommand(
        //    () =>
        //    {
        //        OrderLock = true;
        //        CustomerBool = true;
        //        ObservableCollection<Product> tempP = new ObservableCollection<Product>();
        //        ObservableCollection<int> tempQ = new ObservableCollection<int>();
        //        for (int i = 0; i < QuantityList.Count(); i++)
        //        {
        //            if (QuantityList[i] > 0)
        //            {
        //                tempP.Add(ProductList[i]);
        //                tempQ.Add(QuantityList[i]);
        //            }
        //        }
        //        //DataStore.AddLog(new Log("Order Created"));
        //        Order CustomerOrder = new Order(tempP, tempQ);
        //    }));
        //private ICommand searchCommand;
        //public ICommand SearchCommand => searchCommand ?? (searchCommand = new SimpleCommand(
        //    () =>
        //    {
        //        if (EmailAddress == null)
        //        { return; }
        //        DomainPrimatives.Customer.EmailAddress email = new DomainPrimatives.Customer.EmailAddress(EmailAddress);
        //        VerifyBool = true;
        //        EmailLock = true;
        //        ObservableCollection<Customer> temp = new ObservableCollection<Customer>();
        //        foreach (var c in DataStore.GetAllCustomers())
        //        {
        //            if (c.EMail == email)
        //            {
        //                FirstName = c.FirstName.NewName;
        //                LastName = c.LastName.NewName;
        //                sStreet = c.ShippingAddress.Street.AddressStreet;
        //                sCity = c.ShippingAddress.City.AddressCity;
        //                sState = c.ShippingAddress.State.AddressState;
        //                sZip = c.ShippingAddress.Zip.AddressZip;
        //                bStreet = c.BillingAddress.Street.AddressStreet;
        //                bCity = c.BillingAddress.City.AddressCity;
        //                bState = c.BillingAddress.State.AddressState;
        //                bZip = c.BillingAddress.Zip.AddressZip;
        //            }
        //        }




        //    }));


        //private ICommand addCustomerCommand;
        //public ICommand AddCustomerCommand => addCustomerCommand ?? (addCustomerCommand = new SimpleCommand(
        //    () =>
        //    {
        //        DataStore.AddCustomer(new Customer(
        //            FirstName,
        //            LastName,
        //            sStreet,
        //            sCity,
        //            sState,
        //            sZip,
        //            bStreet,
        //            bCity,
        //            bState,
        //            bZip,
        //            EmailAddress));
        //        Customers.Clear();
        //        foreach (var c in DataStore.GetAllCustomers())
        //            Customers.Add(c);
        //    }));
    }
}
