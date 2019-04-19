using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Customer
{
    public class City
    {
        public City(String s)
        {
            if (validateCity(s))
                AddressCity = s;
            else
                failGracefully();
        }

        private string addressCity;
        public string AddressCity
        {
            get; private set;
        }

        public Boolean validateCity(String s)
        {
            // Check length
            if (s.Length > 20)
            {
                //Display string to long message
                return false;
            }
            // Check characters
            if (Regex.IsMatch(s, @"^[a-zA-Z]"))
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
