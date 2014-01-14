using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBMP.Models
{
    public class OrderEventList
    {
        public long ID { get; set; }
        public long OrderID { get; set; }
        public DateTime EventDate { get; set; }
        public string Event { get; set; }
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}