using System;

public class Customer
{
	public Customer(Name firstname,Name lastname, 
                    Street sstreet, City scity, State sstate, Zip szip,
                    Street bstreet, City bcity, State bstate, Zip bstate,
                    EmailAddress email)
	{
        customerID = Guid.NewGuid();

        Name firstName = new Name(firstname);
        Name lastName = new Name(lastname);
        Name fullName = firstName + " " + lastName;

        Address shippingAddress = new Address(sstreet, scity, sstate, szip);
        Address billingAddress = new Address(bstreet, bcity, bstate, bzip);

        EmailAddress emailAddress = new EmailAddress(email);
	}

    public Name firstName;
    private Name FirstName
    {
        get;private set;
    }

}
