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
    
    public partial class ExpensesList
    {
        public string ExpensesCode { get; set; }
        public string ExpensesDescription { get; set; }
        public Nullable<decimal> ExpensesSubAmount { get; set; }
        public Nullable<System.TimeSpan> ExpensesTime { get; set; }
    
        public virtual Expens Expens { get; set; }
    }
}
