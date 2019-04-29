using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Customer
{
    public class Address 
    {
        public Address() { }

        public Address (string str, string c, string st, string z)
        {
            Street = new Street(str);
            City = new City(c);
            State = new State(st);
            Zip = new Zip(z);
        }

        private Street street;
        public Street Street
        {
            get { return street; }
            private set { street = value; }
        }

        private City city;
        public City City
        {
            get { return city; }
            private set { city = value; }
        }

        private State state;
        public State State
        {
            get { return state; }
            private set { state = value; }
        }

        private Zip zip;
        public Zip Zip
        {
            get { return zip; }
            private set { zip = value; }
        }
    }
}
