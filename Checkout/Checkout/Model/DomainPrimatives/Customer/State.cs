using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Customer
{
    public class State
    {
        public State()
        {

        }
        public State(String s)
        {
            if (validateState(s))
            {
                s = s.ToUpper();
                AddressState = s;
            }
            else
                failGracefully();
        }

        private string addressState;
        public string AddressState
        {
            get { return addressState; }
            private set { addressState = value; }
        }

        public Boolean validateState(String s)
        {
            // Check length
            if (s.Length > 2)
            {
                //Display string to long message
                throw new Exception("State can only contain 2 characters");
            }
            // Check characters
            if (Regex.IsMatch(s, @"^[a-zA-Z]"))
            {
                return true;
            }
            else
                throw new Exception("State contains invalid characters");
        }

        public void failGracefully()
        {
            return;
        }
    }
}

