﻿using Checkout.Data;
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

        public void AddLog(Log l)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public ObservableCollection<Customer> GetAllCustomers()
        {
            ObservableCollection<Customer> list = new ObservableCollection<Customer>();
            foreach (var cur in context.GetAllCustomers())
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