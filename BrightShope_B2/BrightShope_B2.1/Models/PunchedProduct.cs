//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrightShope_B2._1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PunchedProduct
    {
        public int Customer_PunchCode_ID { get; set; }
        public string PunchedTransCode { get; set; }
        public string PunchProdCode { get; set; }
        public string PunchProdName { get; set; }
        public Nullable<short> PunchProdQnty { get; set; }
        public Nullable<decimal> SubTotalPrice { get; set; }
        public string PunchProdStatus { get; set; }
    
        public virtual Transaction Transaction { get; set; }
    }
}
