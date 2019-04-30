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
        public Quantity(int i)
        {
            validateQuantity(i);
            Quan = i;
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
            throw new Exception("Quantity must be postive and less than 10");
        }

        public void failGracefully()
        {
            return;
        }
    }
}
