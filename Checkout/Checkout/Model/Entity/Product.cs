using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Checkout.VMs.DomainPrimatives.Product;

namespace Checkout.VMs.Entity
{
    public class Product : INotifyPropertyChanged
    {
        public Product()
        {

        }
        public Product(int id, string name, double price)
        {
            ID = id;
            Name = name;
           Price = price;

        }

        private int _id;
        public int ID
        {   get{ return _id; }
            set { SetField(ref _id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetField(ref name, value); }
        }
        
        private double price;
        public double Price
        {
            get { return price; }
            set { SetField(ref price, value); }
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