using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBMP.Models
{
    public class ProductList
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int PartnerShareType { get; set; }
        public string ShareValue1 { get; set; }
        public string Description { get; set; }
        public string Partner { get; set; }
        public bool ActiveFlag { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}