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
        public Customer()
        {

        }
        public Customer(string id, string firstname, string lastname,
                        string sstreet, string scity, string sstate, string szip,
                        string bstreet, string bcity, string bstate, string bzip,
                        string email)
        {
            Id = id;

            Name FirstName = new Name(firstname);
            Name LastName = new Name(lastname);

            Address shippingAddress = new Address(sstreet, scity, sstate, szip);
            Address billingAddress = new Address(bstreet, bcity, bstate, bzip);

            EmailAddress eMail = new EmailAddress(email);
        }

        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        private Name firstName;
        public Name FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private Name lastName;
        public Name LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private Address shippingAddress;
        public Address ShippingAddress
        {
            get { return shippingAddress; }
            set { shippingAddress = value; }
        }

        private Address billingAddress;
        public Address BillingAddress
        {
            get { return billingAddress; }
            set { billingAddress = value; }
        }

        private EmailAddress eMail;
        public EmailAddress EMail
        {
            get { return eMail; }
            set { eMail = value; }
        }


    }
}
