using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Order
{
    public class Quantity
    {
        public Quantity()
        {

        }
        public Quantity(string i)
        {
            int x = 0;
            // TryParse tries to make i into an integer, if successful, expression is true and x is the integer
            if (Int32.TryParse(i, out x))
            {
                validateQuantity(x);
            }
        }

        public int Quan
        {
            get; private set;
        }

        public Boolean validateQuantity(int i)
        {
            // Check value range of quantity
            if (i >= 0 && i < 10)
            {
                return true;
            }
            else return false;
        }

        public void failGracefully()
        {
            return;
        }
    }
}
