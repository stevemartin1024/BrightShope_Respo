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
    
    public partial class InventoryEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryEntry()
        {
            this.InventoryEntryLists = new HashSet<InventoryEntryList>();
        }
    
        public string EntryCode { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string UserEmail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryEntryList> InventoryEntryLists { get; set; }
    }
}
