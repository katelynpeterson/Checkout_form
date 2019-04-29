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
        public EmailAddress()
        {

        }
        public EmailAddress(String s)
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
            get { return email; }
            private set { email = value; }
        }

        public Boolean validateEmail(String s)
        {
            // Check length

            if (s.Length > 30 || s ==null)
            {
                //Display string to long message
                return false;
            }
            // Check characters
            try
            {
                var mail = new System.Net.Mail.MailAddress(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void failGracefully()
        {
            return;
        }
    }
}

