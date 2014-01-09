using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBMP.Models
{
    public class OrderModel
    {
        public long OrderID { get; set; }
        public string OrderTitle { get; set; } //this is to show OrderID+CustomerName together
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public long CustomerID { get; set; }
        public long SalesRepID { get; set; }
        public int Status { get; set; }

        public IEnumerable<OrderDetailList> OrderDetailLists { get; set; }
    }
}