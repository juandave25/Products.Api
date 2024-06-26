﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Api.Entities
{
    public class Product : Base
    {
        public Product() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}
