using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Customer
{
    public class Name
    {
        public Name()
        {

        }
        public Name(String s)
        {
            if (validateName(s))
            {
                // capitalize the first letter
                s = s.First().ToString().ToUpper() + s.Substring(1);
                newName = s;
            }
                
            else
                failGracefully();
        }

        private string newName;
        public string NewName
        {
            get { return newName; }
            set { newName = value; }
        }

        public Boolean validateName(String s)
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

