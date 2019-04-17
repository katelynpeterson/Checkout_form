using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.VMs.DomainPrimatives.Customer;

namespace Checkout.VMs.Entity
{
    public class Customer
    {
        public Customer(string firstname, string lastname,
                        string sstreet, string scity, string sstate, string szip,
                        string bstreet, string bcity, string bstate, string bzip,
                        string email)
        {
            Guid customerID = Guid.NewGuid();

            Name FirstName = new Name(firstname);
            Name LastName = new Name(lastname);

            Address shippingAddress = new Address(sstreet, scity, sstate, szip);
            Address billingAddress = new Address(bstreet, bcity, bstate, bzip);

            EmailAddress emailAddress = new EmailAddress(email);
        }

        private Name firstName;
        public Name FirstName
        {
            get; private set;
        }

    }
}
