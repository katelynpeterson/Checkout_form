using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkout.VMs.DomainPrimatives.Product
{
    public class ProductName
    {

        public ProductName()
        {

        }
            public ProductName(String s)
            {
                if (validateProductName(s))
                {
                    pName = s;
                }
                else
                    failGracefully();
            }

            private string pName;
            public string PName
            {
                get; private set;
            }

            public Boolean validateProductName(String s)
            {
                // Check length
                if (s.Length > 20)
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


