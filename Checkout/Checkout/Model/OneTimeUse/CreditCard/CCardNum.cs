using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.VMs.OneTimeUse.CreditCard
{
    public class CCardNum
    {
        public CCardNum()
        { }
        
        public bool ValidCharge(long ccnum, int expm, int expy, int cvv)
        {
            if (validateCC(ccnum) && validateCVV(cvv) && validateMonth(expm) && validateYear(expy))
            {
                return checkBankAPI(ccnum, expm, expy, cvv);
            }
            else
            {
                return false;
            }
        }
        public Boolean validateMonth(int month)
        {
            if (month < 1 || month > 12)
                throw new Exception("Invalid Month");
            return true;
        }

        public Boolean validateYear(int year)
        {
            if (year > 2030 || year < 2019)
                throw new Exception("Invalid Year");
            return true;
        }
        public Boolean validateCC(long num)
        {
            if (num.ToString().Length != 16)
                throw new Exception("Invalid Card Number");
            if (luhnAlgorithm(num))
                return true;
            throw new Exception("Invalid Card Number");
        }
        public Boolean validateCVV(int num)
        {
            if (num < 100 || num > 9999)
                throw new Exception("Invalid CVV Number");
            return true;
        }


        public Boolean luhnAlgorithm(long num)
        {
            // There is an elaborate algorithm to do a check sum on a credit card. We are not doing that.
            return true;
        }
        public Boolean checkBankAPI(long ccnum, int expm, int expy, int cvv)
        {
            return true;
        }
        public void failGracefully()
        {
            return;
        }
    }
}
