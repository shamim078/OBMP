//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBMP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MSAReference { get; set; }
        public string Address { get; set; }
        public string PartnerType { get; set; }
        public Nullable<byte> PartnerShare { get; set; }
        public Nullable<System.DateTime> DateRegistered { get; set; }
        public string PrimaryContact { get; set; }
        public string PrimaryContactDetail { get; set; }
        public string SecondaryContact { get; set; }
        public string SecondaryContactDetail { get; set; }
        public string TechnicalContact { get; set; }
        public string TechnicalContactDetail { get; set; }
        public string AdminContact { get; set; }
        public string AdminContactDetail { get; set; }
        public string Escalation { get; set; }
        public byte[] MSAContractDocument { get; set; }
        public string ServiceDescription { get; set; }
    }
}
