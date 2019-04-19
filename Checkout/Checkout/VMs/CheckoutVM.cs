using Checkout.Data;
using Checkout.Database;
using Checkout.VMs.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.VMs
{
    public class CheckoutVM : INotifyPropertyChanged
    {
            public ObservableCollection<Product> ProductList
        {
            get; set;
        }

        //public Product NewProduct { get; private set; }

        public CheckoutVM() {
            
            Product1 = new Product (1, "African Safari", 2000.00 );
            Product2 = new Product (2, "Mexico Safari", 1500.00 );
            Product3 = new Product (3, "Australian Safari", 4200.00 );
            Product4 = new Product (4, "Antarctic Safari", 7100.00 );
            CustomerBool = false;
        }

        private bool customerBool;
        public bool CustomerBool
        {
            get { return customerBool; }
            set { SetField(ref customerBool, value); }
        }

        private readonly IDataStore dataStore;

        public CheckoutVM(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            Customers = new ObservableCollection<Customer>(DataStore.GetAllCustomers());
                
        }

        public IDataStore DataStore => dataStore;

        private Product product1;
        public Product Product1
        {
            get { return product1; }
            set { SetField(ref product1, value); }
        }

        private Product product2;
        public Product Product2
        {
            get { return product2; }
            set { SetField(ref product2, value); }
        }

        private Product product3;
        public Product Product3
        {
            get { return product3; }
            set { SetField(ref product3, value); }
        }

        private Product product4;
        public Product Product4
        {
            get { return product4; }
            set { SetField(ref product4, value); }
        }

        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set { SetField(ref firstname, value); }
        }

        private string lastname;
        public string Lastname
        {
            get { return lastname; }
            set { SetField(ref lastname, value); }
        }

        private string shippingStreet;
        public string ShippingStreet
        {
            get { return shippingStreet; }
            set { SetField(ref shippingStreet, value); }
        }

        private string shippingCity;
        public string ShippingCity
        {
            get { return shippingCity; }
            set { SetField(ref shippingCity, value); }
        }

        private string shippingState;
        public string ShippingState
        {
            get { return shippingState; }
            set { SetField(ref shippingState, value); }
        }

        private string shippingZip;
        public string ShippingZip
        {
            get { return shippingZip; }
            set { SetField(ref shippingZip, value); }
        }

        private string billingStreet;
        public string BillingStreet
        {
            get { return billingStreet; }
            set { SetField(ref billingStreet, value); }
        }

        private string billingCity;
        public string BillingCity
        {
            get { return billingCity; }
            set { SetField(ref billingCity, value); }
        }

        private string billingState;
        public string BillingState
        {
            get { return billingState; }
            set { SetField(ref billingState, value); }
        }

        private string billingZip;
        public string BillingZip
        {
            get { return billingZip; }
            set { SetField(ref billingZip, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { SetField(ref email, value); }
        }

        private SimpleCommand addCustomerCommand;
        public SimpleCommand AddCustomerCommand => addCustomerCommand ?? (addCustomerCommand = new SimpleCommand(
            () =>
            {
                DataStore.AddCustomer(new Customer(
                    Firstname,
                    Lastname,
                    ShippingStreet,
                    ShippingCity,
                    ShippingState,
                    ShippingZip,
                    BillingStreet,
                    BillingCity,
                    BillingState,
                    BillingZip,
                    Email));
                Customers.Clear();
                foreach (var c in DataStore.GetAllCustomers())
                    Customers.Add(c);
            }));

        public ObservableCollection<Customer> Customers { get; private set; }
               
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
