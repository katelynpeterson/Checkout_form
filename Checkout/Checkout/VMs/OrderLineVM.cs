using Checkout.VMs.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.VMs
{
    class OrderLineVM :INotifyPropertyChanged
    {
        private Product product;
        public Product MyProperty
        {
            get { return product; }
            set { SetField(ref product, value); }
        }

        private int quantity;
        public int Quantity
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
