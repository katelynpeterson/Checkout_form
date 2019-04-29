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
using Checkout.VMs.DomainPrimatives;
using Checkout.VMs.DomainPrimatives.Order;
using Checkout.Model;

namespace Checkout.VMs
{
    public class CheckoutVM : INotifyPropertyChanged    
    {

        private readonly IDataStore dataStore;
        public IDataStore DataStore => dataStore;

        public CheckoutVM(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            //Customers = new ObservableCollection<Customer>(DataStore.GetAllCustomers());
            //ProductList = new ObservableCollection<Product>();
            //ProductList.Add(new Product(1, "African Safari", 2000.00));
            //ProductList.Add(new Product(2, "Mexico Safari", 1500.00));
            //ProductList.Add(new Product(3, "Australian Safari", 4200.00));
            //ProductList.Add(new Product(4, "Antarctic Safari", 7100.00));
            //foreach (var p in ProductList)
            //{
            //    dataStore.AddProduct(p);
            //}
            Customer c = new Customer("10", "joe", "blow", "123 anywhere", "ephraim", "ut", "84627", "po box 123", "ephraim", "ut", "84627", "joe@joe.com");
            dataStore.AddCustomer(c);
        }
        public CheckoutVM()
        {
            //Quantities = new ObservableCollection<Quantity>();
            //QuantityList = new ObservableCollection<int>();
            
        
            //for (int i = 0; i < ProductList.Count(); i++)
            //    Quantities.Add(new Quantity("0"));
            //    QuantityList.Add (0);
            //Total = 0;

            //CustomerBool = false;
            //VerifyBool = false;
            //FinalBool = false;
        }

    

        //private bool customerBool;
        //public bool CustomerBool
        //{
        //    get { return customerBool; }
        //    set { SetField(ref customerBool, value); }
        //}
        //private bool verifyBool;
        //public bool VerifyBool
        //{
        //    get { return verifyBool; }
        //    set { SetField(ref verifyBool, value); }
        //}
        //private bool finalBool;
        //public bool FinalBool
        //{
        //    get { return finalBool; }
        //    set { SetField(ref finalBool, value); }
        //}



        private string myName;
        public string MyName
        {
            get { return myName; }
            set { myName = value;
                OnPropertyChanged();
            }
        }

        //private double total;
        //public double Total
        //{
        //    get
        //    {
        //        return total;
        //    }
        //    set
        //    {
        //        total = 0;

        //        for (int i = 0; i < ProductList.Count(); i++)
        //        {
        //            total += ProductList[i].Cost * QuantityList[i];
        //        }
        //        OnPropertyChanged("Total");

        //    }}

        //private string firstname;
        //public string FirstName
        //{
        //    get { return firstname; }
        //    set { SetField(ref firstname, value); }
        //}

        //private string lastname;
        //public string LastName
        //{
        //    get { return lastname; }
        //    set { SetField(ref lastname, value); }
        //}

        //private string shippingStreet;
        //public string sStreet
        //{
        //    get { return shippingStreet; }
        //    set { SetField(ref shippingStreet, value); }
        //}

        //private string shippingCity;
        //public string sCity
        //{
        //    get { return shippingCity; }
        //    set { SetField(ref shippingCity, value); }
        //}

        //private string shippingState;
        //public string sState
        //{
        //    get { return shippingState; }
        //    set { SetField(ref shippingState, value); }
        //}

        //private string shippingZip;
        //public string sZip
        //{
        //    get { return shippingZip; }
        //    set { SetField(ref shippingZip, value); }
        //}

        //private string billingStreet;
        //public string bStreet
        //{
        //    get { return billingStreet; }
        //    set { SetField(ref billingStreet, value); }
        //}

        //private string billingCity;
        //public string bCity
        //{
        //    get { return billingCity; }
        //    set { SetField(ref billingCity, value); }
        //}

        //private string billingState;
        //public string bState
        //{
        //    get { return billingState; }
        //    set { SetField(ref billingState, value); }
        //}

        //private string billingZip;
        //public string bZip
        //{
        //    get { return billingZip; }
        //    set { SetField(ref billingZip, value); }
        //}

        //private bool isNewCustomer;
        //public bool IsNewCustomer
        //{
        //    get { return isNewCustomer; }
        //    set { SetField(ref isNewCustomer, value); }
        //}

        //private string emailAddress;
        //public string EmailAddress
        //{
        //    get { return emailAddress; }
        //    set { SetField(ref emailAddress, value); }
        //}
        //private bool emailLock;
        //public bool EmailLock
        //{
        //    get { return emailLock; }
        //    set { SetField(ref emailLock, value); }
        //}

        //private bool orderLock;
        //public bool OrderLock
        //{
        //    get { return orderLock; }
        //    set { SetField(ref orderLock, value); }
        //}

        private ICommand addMyNameToDb;
        public ICommand AddMyNameToDb=> addMyNameToDb ??(addMyNameToDb = new SimpleCommand(
           ()=>
        {
            MyName name = new MyName(MyName);
            dataStore.AddMeToDb(name);
        }));


        //private ICommand purchaseCommand;
        //public ICommand PurchaseCommand => purchaseCommand ?? (purchaseCommand = new SimpleCommand(
        //    () =>
        //    {
        //        OrderLock = true;
        //        CustomerBool = true;
        //        ObservableCollection<Product> tempP = new ObservableCollection<Product>();
        //        ObservableCollection<int> tempQ = new ObservableCollection<int>();
        //       for (int i = 0; i< QuantityList.Count(); i++)
        //        {
        //            if (QuantityList[i] > 0)
        //            {
        //                tempP.Add(ProductList[i]);
        //                tempQ.Add(QuantityList[i]);
        //            }
        //        }
        //       //DataStore.AddLog(new Log("Order Created"));
        //       Order CustomerOrder = new Order(tempP, tempQ);
        //    }));
        //private ICommand searchCommand;
        //public ICommand SearchCommand => searchCommand ?? (searchCommand = new SimpleCommand(
        //    () =>
        //    {   if(EmailAddress == null)
        //            { return; }
        //        DomainPrimatives.Customer.EmailAddress email = new DomainPrimatives.Customer.EmailAddress(EmailAddress);
        //        VerifyBool = true;
        //        EmailLock = true;
        //        ObservableCollection<Customer> temp = new ObservableCollection<Customer>();
        //            foreach (var c in DataStore.GetAllCustomers())
        //            {
        //                if (c.EMail == email)
        //                {
        //                    FirstName = c.FirstName.NewName;
        //                    LastName = c.LastName.NewName;
        //                    sStreet = c.ShippingAddress.Street.AddressStreet;
        //                    sCity = c.ShippingAddress.City.AddressCity;
        //                    sState = c.ShippingAddress.State.AddressState;
        //                    sZip = c.ShippingAddress.Zip.AddressZip;
        //                    bStreet = c.BillingAddress.Street.AddressStreet;
        //                    bCity = c.BillingAddress.City.AddressCity;
        //                    bState = c.BillingAddress.State.AddressState;
        //                    bZip = c.BillingAddress.Zip.AddressZip;
        //                }
        //            }
                    

                

        //    }));


        //private ICommand addCustomerCommand;
        //public ICommand AddCustomerCommand =>addCustomerCommand ?? (addCustomerCommand = new SimpleCommand(
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

        //public ObservableCollection<Customer> Customers { get; private set; }
        //public ObservableCollection<Order> OrderList{ get; set;}
        //public ObservableCollection<Order> CustomerOrderList{get;set;}
        //public Product NewProduct { get; private set; }
        //public ObservableCollection<Product> ProductList{ get; private set; }
        //public ObservableCollection<Quantity> Quantities{ get; private set;}
        //public ObservableCollection<int> QuantityList{get; private set;}
               
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
