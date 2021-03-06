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
    
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            this.PunchedProducts = new HashSet<PunchedProduct>();
            this.SaleTransactions = new HashSet<SaleTransaction>();
        }
    
        public string TransCode { get; set; }
        public string TransEmail { get; set; }
        public string TransDateTime { get; set; }
        public Nullable<decimal> TransTotalPrice { get; set; }
        public Nullable<decimal> TransCash { get; set; }
        public Nullable<decimal> TransChange { get; set; }
        public Nullable<byte> TransNo_Item { get; set; }
        public string TransStatus { get; set; }
        public string Trans_Type { get; set; }
        public string Trans_Order { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PunchedProduct> PunchedProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleTransaction> SaleTransactions { get; set; }
        public virtual User User { get; set; }
    }
}
