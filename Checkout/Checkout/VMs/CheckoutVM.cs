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
using System.Windows.Input;

namespace Checkout.VMs
{
    public class CheckoutVM : INotifyPropertyChanged
    {

        public CheckoutVM() {

            Product1 = new Product { ID = 1, Name = "African Safari", Price = 2000.00, Quantity =0 };
            Product2 = new Product { ID = 2, Name = "Dream Catcher", Price = 35.00, Quantity = 0 };
            Product3 = new Product { ID = 3, Name = "African Safari", Price = 2000.00, Quantity = 0 };
            Product4 = new Product { ID = 4, Name = "African Safari", Price = 2000.00, Quantity = 0 };
            ProductList.Add(Product1);
            ProductList.Add(Product2);
            ProductList.Add(Product3);
            ProductList.Add(Product4);
        }

        private readonly IDataStore dataStore;

        public CheckoutVM(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            Customers = new ObservableCollection<Customer>(DataStore.GetAllCustomers());
        }

        public IDataStore DataStore => dataStore;

        //variables
        #region
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
        #endregion 

        private ICommand purchaseCommand;
        public ICommand PurchaseCommand => purchaseCommand ?? (purchaseCommand = new SimpleCommand(
            ()=>
            {
                ObservableCollection<Product> temp = new ObservableCollection<Product>();
                foreach(var item in ProductList)
                {
                    if(item.Quantity>0)
                    {
                        temp.Add(item);
                    }
                }
                foreach(var item in temp)
                {
                    CustomerOrderList.Add(item);
                }
            }));


        private ICommand addCustomerCommand;
        public ICommand AddCustomerCommand => addCustomerCommand ?? (addCustomerCommand = new SimpleCommand(
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
        public ObservableCollection<Product> CustomerOrderList { get; private set; }
        public ObservableCollection<Product> ProductList { get; private set; }
               
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
