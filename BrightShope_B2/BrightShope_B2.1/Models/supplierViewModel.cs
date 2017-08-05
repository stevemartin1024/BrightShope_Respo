using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrightShope_B2._1.Models
{
    public class supplierViewModel
    {   
        public string SupplierID { get; set; }
        [Required(ErrorMessage="Supplier Name")]
        public string SuppName { get; set; }
        [Required(ErrorMessage = "Exact Address")]
        public string SuppAddress { get; set; }
        [Required(ErrorMessage = "Current City")]
        public string SuppCity_Prov { get; set; }
        [Required(ErrorMessage = "Contact Number")]
        public string SuppContact_ { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string SuppEmail { get; set; }
        public string SuppRemarks { get; set; }
        public string SuppStatus { get; set; }
    }
}