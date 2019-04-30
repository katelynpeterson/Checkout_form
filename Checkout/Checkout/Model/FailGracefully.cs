using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.Model
{
    public class FailGracefully : System.Exception
    {
        public FailGracefully()
        {

        }

        public FailGracefully(string message)
        {
            if (validateMessage(message))
            {
                Message = message;
                //log message
            }
            else
                throw new FailGracefully(Message);
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public Boolean validateMessage(String s)
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
    }
}
