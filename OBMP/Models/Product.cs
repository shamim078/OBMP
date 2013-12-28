﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBMP.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }

    }
}