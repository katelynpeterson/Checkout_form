using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Customer
{
    public class Address 
    {
        public Address (string str, string c, string st, string z)
        {
            Street street = new Street(str);
            City city = new City(c);
            State state = new State(st);
            Zip zip = new Zip(z);
        }
        
    }
}
