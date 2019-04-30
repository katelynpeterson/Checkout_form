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
                throw new Exception("Invalid email address.");
        }

        private string email;
        public string Email
        {
            get { return email; }
            private set { email = value; }
        }

        public Boolean validateEmail(String s)
        {
            // Check null
            if (s == null)
            {
                throw new Exception("Email cannot be null");
            }
            // Check length

            if (s.Length > 30)
            {
                //Display string to long message
                throw new Exception("Email cannot exceed 30 characters");
            }
            // Check characters
            try
            {
                var mail = new System.Net.Mail.MailAddress(s);
                return true;
            }
            catch
            {
                throw new Exception("That is not a valid email address");
            }
        }

        public void failGracefully()
        {
            return;
        }
    }
}

