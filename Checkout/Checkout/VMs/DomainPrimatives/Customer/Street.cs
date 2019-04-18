using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Customer
{
    public class Street
    {
        public Street(String s)
        {
            if (validateStreet(s))
                AddressStreet = s;
            else
                failGracefully();
        }

        private string addressStreet;
        public string AddressStreet
        {
            get; private set;
        }

        public Boolean validateStreet(String s)
        {
            // Check length
            if (s.Length > 40)
            {
                //Display string to long message
                return false;
            }
            // Check characters
            if (Regex.IsMatch(s, @"^[a-zA-Z0-9] + $"))
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

