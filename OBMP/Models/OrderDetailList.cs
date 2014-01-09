using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBMP.Models
{
    public class OrderDetailList
    {
        public long OrderDetailID { get; set; }
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? OrderQuantity { get; set; }
        public decimal? LineTotal { get; set; }
    }
}