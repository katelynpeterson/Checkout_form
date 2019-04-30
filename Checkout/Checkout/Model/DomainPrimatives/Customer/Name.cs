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
                NewName = s;
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
            // Check null
            if (s == null)
            {
                throw new Exception("Name cannot be blank");
            }
            // Check length
            if (s.Length > 20)
            {
                //Display string to long message
                throw new Exception("Name must be less than 20 characters");
            }
            // Check characters
            if (Regex.IsMatch(s, @"^[a-zA-Z]"))
            {
                return true;
            }
            else
                throw new Exception("Invalid Characters in Name");
        }

        public void failGracefully()
        {
            return;
        }
    }
}

