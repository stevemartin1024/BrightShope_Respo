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
    
    public partial class UserOrder
    {
        public int UserOrderID { get; set; }
        public string UserEmail { get; set; }
        public int OrderCode { get; set; }
    
        public virtual OrderTable OrderTable { get; set; }
        public virtual User User { get; set; }
    }
}