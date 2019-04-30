using Checkout.Model;
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
        private FailGracefully failGracefully;
        public City()
        {

        }
        public City(String s)
        {
            failGracefully = new FailGracefully();
            if (validateCity(s))
                AddressCity = s;
            else
            {
            failGracefully.Message = "City contains " + CityError;
            throw new Exception(failGracefully.Message);

            }
        }

        private string addressCity;
        public string AddressCity
        {
            get { return addressCity; }
            private set { addressCity = value; }
        }


        private string cityError;
        public string CityError
        {
            get { return cityError; }
            set { cityError = value; }
        }

        public Boolean validateCity(String s)
        {
            // Check length
            if (s.Length > 20 || s==null || s=="")
            {
                //Display string to long message
                CityError = "too many or too few characters";
                return false;
            }
            // Check characters
            if (Regex.IsMatch(s, @"^[a-zA-Z]"))
            {
                return true;
            }
            else {
                CityError = "invalid characters";
                return false; }
        }

    }
}
