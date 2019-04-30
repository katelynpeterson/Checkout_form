using Checkout.Data;
using Checkout.Database;
using Checkout.Model;
using Checkout.VMs.DomainPrimatives;
using Checkout.VMs.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.VMs
{
    public class TypeConverter : IDataStore
    {
        private readonly IDtoStore context;
        public TypeConverter(string dbPath)
        {
            context = new Checkout.Data.Database(dbPath);
        }

        public void AddCustomer(Customer c)
        {
            var temp = new Checkout.Database.DTO.CustomerDTO();
            temp.Id = c.Id.ToString();
            temp.Firstname = c.FirstName.NewName;
            temp.Lastname = c.LastName.NewName;
            temp.ShippingStreet = c.ShippingAddress.Street.AddressStreet;
            temp.ShippingCity = c.ShippingAddress.City.AddressCity;
            temp.ShippingState = c.ShippingAddress.State.AddressState;
            temp.ShippingZip = c.ShippingAddress.Zip.AddressZip;
            temp.BillingStreet = c.BillingAddress.Street.AddressStreet;
            temp.BillingCity = c.BillingAddress.City.AddressCity;
            temp.BillingState = c.BillingAddress.State.AddressState;
            temp.BillingZip = c.BillingAddress.Zip.AddressZip;
            temp.EmailAddress = c.EMail.Email;

            context.AddCustomer(temp);
        }

        public void UpdateCustomer(Customer c)
        {
            var temp = new Checkout.Database.DTO.CustomerDTO();
            //temp.Id = c.Id.ToString();
            temp.Firstname = c.FirstName.NewName;
            temp.Lastname = c.LastName.NewName;
            temp.ShippingStreet = c.ShippingAddress.Street.AddressStreet;
            temp.ShippingCity = c.ShippingAddress.City.AddressCity;
            temp.ShippingState = c.ShippingAddress.State.AddressState;
            temp.ShippingZip = c.ShippingAddress.Zip.AddressZip;
            temp.BillingStreet = c.BillingAddress.Street.AddressStreet;
            temp.BillingCity = c.BillingAddress.City.AddressCity;
            temp.BillingState = c.BillingAddress.State.AddressState;
            temp.BillingZip = c.BillingAddress.Zip.AddressZip;
            //temp.EmailAddress = c.EMail.Email;

            context.UpdateCustomer(temp);
        }

        public void AddLog(Log l)
        {
            var temp = new Checkout.Database.DTO.LogDTO();
            temp.DateStamp = l.DateStamp;
            temp.Message = l.Message;
            context.AddLog(temp);
        }

        public void AddMeToDb(MyName myName)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order o)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product p)
        {
            var temp = new Checkout.Database.DTO.ProductDTO();
            temp.Id = p.ID;
            temp.Name = p.Name.NewName;
            temp.Price = p.Price.ProductPrice;
            temp.Quantity = p.Quantity.Quan;

            context.AddProduct(temp);
        }

        public ObservableCollection<Product> GetAllProducts()
        {
            ObservableCollection<Product> list = new ObservableCollection<Product>();
            foreach (var cur in context.GetAllProducts())
            {
                list.Add(new Product(cur.Id, cur.Name, cur.Price, cur.Quantity));
            }
            return list;
        }

        public ObservableCollection<Customer> GetAllCustomers()
        {
            ObservableCollection<Customer> list = new ObservableCollection<Customer>();
            foreach (var cur in context.GetAllCustomers())
            {
                list.Add(new Customer(cur.Firstname, cur.Lastname, cur.ShippingStreet, cur.ShippingCity,
                    cur.ShippingState, cur.ShippingZip, cur.BillingStreet, cur.BillingCity,
                    cur.BillingState, cur.BillingZip, cur.EmailAddress));
            }
            return list;
        }

        public ObservableCollection<Customer> GetCustomerByEmail(string email)
        {

            ObservableCollection<Customer> list = new ObservableCollection<Customer>();
            //var temp = new Checkout.Database.DTO.CustomerDTO();
            //temp.EmailAddress = email;
            foreach (var cur in context.GetCustomerByEmail(email))
            {

                list.Add(new Customer(cur.Id, cur.Firstname, cur.Lastname, cur.ShippingStreet, cur.ShippingCity,
                    cur.ShippingState, cur.ShippingZip, cur.BillingStreet, cur.BillingCity,
                    cur.BillingState, cur.BillingZip, cur.EmailAddress));
            }
            return list;

        }

        public void PurchaseProduct(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
