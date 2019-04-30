using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives
{
    public class Log
    {
        public Log()
        {

        }
        public Log(string message)
        {
            Message = message;
            DateStamp = DateTime.Now;
        }

        private string message;
        public string Message
        {
            get { return message; }
            private set { message = value; }
        }

        private DateTime dateStamp;
        public DateTime DateStamp
        {
            get;private set;
        }
    }
}
