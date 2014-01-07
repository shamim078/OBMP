using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBMP.Models
{
    public class CustomerSaleRep
    {
        public long ID { get; set; }
        public string UID { get; set; }
        public string Name { get; set; }
        public string AccountReference { get; set; }
        public int SaleRepID { get; set; }
        public string ContactPerson { get; set; }
       
    }
}