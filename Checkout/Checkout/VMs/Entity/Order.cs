﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.VMs.Entity
{
    public class Order
    {
        public Order(int quantity)
        {
            int Quantity = quantity;
        }
        Guid orderID = Guid.NewGuid();

    }
}
