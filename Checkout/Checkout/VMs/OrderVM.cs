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
    class OrderVM : INotifyPropertyChanged
    {
        private double total;
        public double Total
        {
            get { return total; }
            set { SetField(ref total, value); }
        }

        private ObservableCollection<OrderLineVM> line;
        public ObservableCollection<OrderLineVM> Lines
        {
            set {
                OnPropertyChanged("Total"); }
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
