using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Order
{
    public class Quantity : INotifyPropertyChanged
    {
        public Quantity()
        {

        }
        public Quantity(int i)
        {
            if (validateQuantity(i))
            {

            Quan = i;
            }
        }
        private int quan;
        public int Quan
        {
            get { return quan; }
            set {
                if (validateQuantity(value))
                {
                    quan = value;
                    OnPropertyChanged();
                }
                else
                    throw new Exception("Invalid Quantity");

                }

        }

        public Boolean validateQuantity(int i)
        {
            // Check value range of quantity
            if (i < 0 || i > 50)
            {
            throw new Exception("Quantity must be postive and less than 10");
            }
                return true;
        }

        public void failGracefully()
        {
            return;
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
