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
    
    public partial class Expens
    {
        public string ExpensesCode { get; set; }
        public Nullable<decimal> ExpensesTotalAmount { get; set; }
        public Nullable<System.DateTime> ExpensesDate { get; set; }
    
        public virtual ExpensesList ExpensesList { get; set; }
    }
}
