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
using Checkout.VMs.DomainPrimatives.Customer;
using System.Windows;
using Checkout.VMs.OneTimeUse.CreditCard;

namespace Checkout.VMs
{
    public class CheckoutVM : INotifyPropertyChanged
    {

        private readonly IDataStore dataStore;
        public IDataStore DataStore => dataStore;

        public CheckoutVM() { }
        public CheckoutVM(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            ProductList = new ObservableCollection<Product>();
            ProductList.Add(new Product(1, "African Safari", 2000.00, 0));
            ProductList.Add(new Product(2, "Mexico Safari", 1500.00, 0));
            ProductList.Add(new Product(3, "Australian Safari", 4200.00, 0));
            ProductList.Add(new Product(4, "Antarctic Safari", 7100.00, 0));
            foreach (var p in ProductList)
            {
                dataStore.AddProduct(p);
            }
            Customer c = new Customer("joe", "blow", "123 anywhere", "ephraim", "ut", "84627", "po box 123", "ephraim", "ut", "84627", "joe@joe.com");
            dataStore.AddCustomer(c);
            Customers = new ObservableCollection<Customer>(DataStore.GetAllCustomers());
            Products = new ObservableCollection<Product>(DataStore.GetAllProducts());
            SelectedCustomer = new ObservableCollection<Customer>();
            CustomerBool = false;
            VerifyBool = false;
            FinalBool = false;
            CustomerLock = false;
            OrderLock = false;
            Total = 0;

        }

        //bools and locks
        #region
        private bool customerBool;
        public bool CustomerBool
        {
            get { return customerBool; }
            set { SetField(ref customerBool, value); }
        }

        private bool verifyBool;
        public bool VerifyBool
        {
            get { return verifyBool; }
            set { SetField(ref verifyBool, value); }
        }
        private bool finalBool;
        public bool FinalBool
        {
            get { return finalBool; }
            set { SetField(ref finalBool, value); }
        }

        private bool orderLock;
        public bool OrderLock
        {
            get { return orderLock; }
            set { SetField(ref orderLock, value); }
        }


        private bool emailLock;
        public bool EmailLock
        {
            get { return emailLock; }
            set { SetField(ref emailLock, value); }
        }

        private bool customerLock;
        public bool CustomerLock
        {
            get { return customerLock; }
            set { SetField(ref customerLock, value); }
        }
        #endregion

        //private string myName;
        //public string MyName
        //{
        //    get { return myName; }
        //    set { myName = value;
        //        OnPropertyChanged();
        //    }
        //}

        private double total;
        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                double sum = 0;
                for (int i = 0; i < Products.Count(); i++)
                {
                    sum += Products[i].Price.ProductPrice * Products[i].Quantity.Quan;
                }
                SetField(ref total, sum);

            }
        }

        //properties
        #region

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { SetField(ref quantity, value); }
        }


        private string firstname;
        public string FirstName
        {
            get { return firstname; }
            set { SetField(ref firstname, value); }
        }

        private string lastname;
        public string LastName
        {
            get { return lastname; }
            set { SetField(ref lastname, value); }
        }

        private string shippingStreet;
        public string sStreet
        {
            get { return shippingStreet; }
            set { SetField(ref shippingStreet, value); }
        }

        private string shippingCity;
        public string sCity
        {
            get { return shippingCity; }
            set { SetField(ref shippingCity, value); }
        }

        private string shippingState;
        public string sState
        {
            get { return shippingState; }
            set { SetField(ref shippingState, value); }
        }

        private string shippingZip;
        public string sZip
        {
            get { return shippingZip; }
            set { SetField(ref shippingZip, value); }
        }

        private string billingStreet;
        public string bStreet
        {
            get { return billingStreet; }
            set { SetField(ref billingStreet, value); }
        }

        private string billingCity;
        public string bCity
        {
            get { return billingCity; }
            set { SetField(ref billingCity, value); }
        }

        private string billingState;
        public string bState
        {
            get { return billingState; }
            set { SetField(ref billingState, value); }
        }

        private string billingZip;
        public string bZip
        {
            get { return billingZip; }
            set { SetField(ref billingZip, value); }
        }

        private bool isNewCustomer;
        public bool IsNewCustomer
        {
            get { return isNewCustomer; }
            set { SetField(ref isNewCustomer, value); }
        }

        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set { SetField(ref emailAddress, value); }
        }

        private long cCardNum;
        public long CCNUM
        {
            get { return cCardNum; }
            set { SetField(ref cCardNum, value); }
        }

        private int expMonth;
        public int ExpMonth
        {
            get { return expMonth; }
            set { SetField(ref expMonth, value); }
        }

        private int expYear;
        public int ExpYear
        {
            get { return expYear; }
            set { SetField(ref expYear, value); }
        }

        private int cvv;
        public int CVV
        {
            get { return cvv; }
            set { SetField(ref cvv, value); }
        }
        #endregion

        //private ICommand addMyNameToDb;
        //public ICommand AddMyNameToDb=> addMyNameToDb ??(addMyNameToDb = new SimpleCommand(
        //   ()=>
        //{
        //    MyName name = new MyName(MyName);
        //    dataStore.AddMeToDb(name);
        //}));


        private ICommand purchaseCommand;
        public ICommand PurchaseCommand => purchaseCommand ?? (purchaseCommand = new SimpleCommand(
            () =>
            {
                try
                {
                    foreach (var p in Products)
                    {
                            Total += p.Cost;
                        //if (p.Quantity.validateQuantity(p.Quantity.Quan))
                        //{

                        //}
                    }
                    OrderLock = true;
                    CustomerBool = true;
                    dataStore.AddLog(new Log("Completed Order"));
                }
                catch (Exception e) {
                    dataStore.AddLog(new Log(e.Message));
                    MessageBox.Show(e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error); }
                
            }));

        private ICommand searchCommand;
        public ICommand SearchCommand => searchCommand ?? (searchCommand = new SimpleCommand(
            () =>
            {
                if (EmailAddress == null)
                {
                    return;
                }
                if (EmailAddress != null)
                {
                    try
                    {

                        var email = new EmailAddress(EmailAddress);


                        VerifyBool = true;
                        EmailLock = true;
                        SelectedCustomer = dataStore.GetCustomerByEmail(EmailAddress);
                        if (SelectedCustomer.Count != 0)
                        {
                            foreach (var c in SelectedCustomer)
                            {
                                FirstName = c.FirstName.NewName;
                                LastName = c.LastName.NewName;
                                sStreet = c.ShippingAddress.Street.AddressStreet;
                                sCity = c.ShippingAddress.City.AddressCity;
                                sState = c.ShippingAddress.State.AddressState;
                                sZip = c.ShippingAddress.Zip.AddressZip;
                                bStreet = c.BillingAddress.Street.AddressStreet;
                                bCity = c.BillingAddress.City.AddressCity;
                                bState = c.BillingAddress.State.AddressState;
                                bZip = c.BillingAddress.Zip.AddressZip;
                            }
                        }
                        else
                            IsNewCustomer = true;
                        dataStore.AddLog(new Log("Looked up Customer"));
                    }
                    catch (Exception e)
                    {
                        dataStore.AddLog(new Log(e.Message));
                        MessageBox.Show(e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }));


        private ICommand addCustomerCommand;
        public ICommand AddCustomerCommand => addCustomerCommand ?? (addCustomerCommand = new SimpleCommand(
            () =>
            {
                //add new customer
                if (IsNewCustomer == true)
                {
                    try
                    {
                        Customer c = new Customer(
                        FirstName,
                        LastName,
                        sStreet,
                        sCity,
                        sState,
                        sZip,
                        bStreet,
                        bCity,
                        bState,
                        bZip,
                        EmailAddress);
                        dataStore.AddCustomer(c);
                        FinalBool = true;
                        CustomerLock = true;
                    dataStore.AddLog(new Log("Successfully Created new Customer"));
                    }
                    catch (Exception e)
                    {
                        dataStore.AddLog(new Log(e.Message));
                        MessageBox.Show(e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                //update existing customer
                else
                {
                    //foreach (var c in SelectedCustomer)
                    //{
                    //    c.FirstName = new Name(FirstName);
                    //    c.LastName = new Name(LastName);
                    //    c.ShippingAddress = new Address(sStreet,sCity,sState, sZip);
                    //    c.BillingAddress =new Address(bStreet, bCity, bState, bZip);
                    //dataStore.UpdateCustomer(c);
                    //}
                    FinalBool = true;
                    CustomerLock = true;
                }

            }));

        private ICommand submit;
        public ICommand Submit => submit ?? (submit = new SimpleCommand(
            () =>
            {
                try
                {
                    var c = new CCardNum();
                    var cardIsValid = c.ValidCharge(CCNUM, expMonth, expYear, CVV);

                    if (cardIsValid)
                    {
                        //display order
                        MessageBox.Show("Your order was created successfully:)", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                        dataStore.AddLog(new Log("Transaction Completed"));
                    }
                }
                catch (Exception e) {
                    dataStore.AddLog(new Log(e.Message));
                    MessageBox.Show(e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error); }
            }));


        public ObservableCollection<Customer> Customers { get; private set; }
        public ObservableCollection<Customer> SelectedCustomer { get; private set; }
        public ObservableCollection<Product> Products { get; private set; }
        //public ObservableCollection<Order> OrderList{ get; set;}
        //public ObservableCollection<Order> CustomerOrderList{get;set;}
        //public Product NewProduct { get; private set; }
        public ObservableCollection<Product> ProductList { get; private set; }
        //public ObservableCollection<Quantity> Quantities { get; private set; }
        //public ObservableCollection<int> QuantityList { get; private set; }

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
