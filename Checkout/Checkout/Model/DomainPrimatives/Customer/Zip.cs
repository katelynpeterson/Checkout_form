using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Customer
{
    public class Zip
    {
        public Zip()
        {

        }
        public Zip(String s)
        {
            if (validateZip(s))
                AddressZip = s;
            else
                failGracefully();
        }

        //private string addressZip;
        public string AddressZip
        {
            get; private set;
        }

        public Boolean validateZip(String s)
        {
            // Check length
            if (s.Length > 10)
            {
                //Display string to long message
                return false;
            }
            // Check characters
            if (Regex.IsMatch(s, @"^[0-9]{5}(?:-[0-9]{4})?$"))
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

