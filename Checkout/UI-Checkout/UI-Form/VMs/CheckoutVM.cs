using System;

public class CheckoutVM

{
	public CheckoutVM()
	{
        createCustomer();
        createOrder();
        checkCredit();
        completeTransaction();
	}
}
