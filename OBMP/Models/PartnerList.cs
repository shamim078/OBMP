using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBMP.Models
{
    public class PartnerList
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string MSAReference { get; set; }
        public string Address { get; set; }
        public string PartnerType { get; set; }
        public int PartnerShare { get; set; }
        public DateTime DateRegistered { get; set; }
        public string PrimaryContact { get; set; }
    }
}