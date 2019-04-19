using Checkout.VMs.DomainPrimatives.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.VMs.Entity 
{
    public class Order : INotifyPropertyChanged
    {
        public Order(ObservableCollection<Product> products, ObservableCollection<int> amounts)
        {
            Products = products;
            Amounts = amounts;
        }
        Guid orderID = Guid.NewGuid();

        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get; private set;
        }

        private ObservableCollection<int> amounts;
         public ObservableCollection<int> Amounts
        {
            get; private set;
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { SetField( ref quantity,value); }   
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
