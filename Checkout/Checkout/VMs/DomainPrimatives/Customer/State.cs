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
            get; private set;
        }

        public Boolean validateState(String s)
        {
            // Check length
            if (s.Length > 2)
            {
                //Display string to long message
                return false;
            }
            // Check characters
            if (Regex.IsMatch(s, @"^[a-zA-Z] + $"))
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
