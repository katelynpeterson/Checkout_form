using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Product
{
    public class Price
    {
        public Price(double f)
        {
            if (validatePrice(f))
            {
                ProductPrice = f;
            }
            else
                failGracefully();
        }

        private double productPrice;
        public double ProductPrice
        {
            get; private set;
        }

        public Boolean validatePrice(double f)
        {
            // Check length
            if (f > 10000)
            {
                //Display string to long message
                return false;
            }
            else return true;
            
        }

        public void failGracefully()
        {
            return;
        }
    }
}

