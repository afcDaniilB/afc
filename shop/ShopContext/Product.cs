﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopContext
{
    public class Product
    {
        public Guid Id { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public int Cost
        {
            get;
            set;
        }

    }
}
