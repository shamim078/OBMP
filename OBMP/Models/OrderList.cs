using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBMP.Models
{
    public class OrderList
    {
        public long OrderID { get; set; }
        public string OrderTitle { get; set; } //this is to show OrderID+CustomerName together
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Customer { get; set; }
        public string SalesRep { get; set; }
        public string Status { get; set; }

    }
}