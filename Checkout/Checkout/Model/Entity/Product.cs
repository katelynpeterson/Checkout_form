using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Checkout.VMs.DomainPrimatives.Customer;
using Checkout.VMs.DomainPrimatives.Order;
using Checkout.VMs.DomainPrimatives.Product;

namespace Checkout.VMs.Entity
{
    public class Product : INotifyPropertyChanged
    {
        public Product()
        {

        }
        public Product(int id, string name, double price, int quantity)
        {
            ID = id;
            Name = new Name(name);
            Price = new Price(price);
            Quantity = new Quantity(quantity);
            Cost = Price.ProductPrice * Quantity.Quan;

        }

        private double cost;
        public double Cost
        {
            get { return cost; }
            set { SetField(ref cost, value); }
        }

        private int _id;
        public int ID
        {   get{ return _id; }
            set { SetField(ref _id, value); }
        }

        private Name name;
        public Name Name
        {
            get { return name; }
            set { SetField(ref name, value); }
        }
        
        private Price price;
        public Price Price
        {
            get { return price; }
            set { SetField(ref price, value); }
        }

        private Quantity quantity;
        public Quantity Quantity
        {
            get { return quantity; }
            set { SetField(ref quantity, value); }
        }




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