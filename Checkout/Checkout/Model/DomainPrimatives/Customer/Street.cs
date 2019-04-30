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
        public Street()
        {

        }
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
            get { return addressStreet; }
            private set { addressStreet = value; }
        }

        public Boolean validateStreet(String s)
        {
            // Check length
            if (s.Length > 40)
            {
                //Display string to long message
                throw new Exception("Street address cannot exceed 40 characters.");
            }
            // Check characters
            if (Regex.IsMatch(s, @"^[a-zA-Z0-9]"))
            {
                return true;
            }
            else
                throw new Exception("There are invalid characters in the Street Address.");
        }

        public void failGracefully()
        {
            return;
        }
    }
}

