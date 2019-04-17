using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Customer
{
    public class EmailAddress
    {
        public EmailAddress (String s)
        {
            if (validateEmail(s))
            {
                // Make all the characters lower case
                s = s.ToLower();
                Email = s;
            }
                
            else
                failGracefully();
        }

        private string email;
        public string Email
        {
            get; private set;
        }

        public Boolean validateEmail(String s)
        {
            // Check length
            if (s.Length > 30)
            {
                //Display string to long message
                return false;
            }
            // Check characters
            if (Regex.IsMatch(s, @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"))
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
}
