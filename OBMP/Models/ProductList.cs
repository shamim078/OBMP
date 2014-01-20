using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBMP.Models
{
    public class ProductList
    {
        public long ID { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ChargeFrequence { get; set; }
        public string ChargeType { get; set; }
        public long Charge { get; set; }
        public string RevenueShareType { get; set; }
        public int FixedOperatorRevenue { get; set; }
        public int FixedPartnerRevenue { get; set; }
        public int PercentageOperatorRevenue { get; set; }
        public int PercentagePartnerRevenue { get; set; }
        public int RecurringFixedMonth { get; set; }
        public string Description { get; set; }
        public string Partner { get; set; }
        public string ProductStatus { get; set; }
        public string CategoryName { get; set; }
        public string MarketPlaceName { get; set; }
    }
}