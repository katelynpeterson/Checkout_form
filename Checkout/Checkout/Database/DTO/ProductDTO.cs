﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Database.DTO
{
    public class ProductDTO
    {
        public ProductDTO() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price{ get; set; }
    }
}
