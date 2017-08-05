using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrightShope_B2._1.Models
{
    public class ProductViewModel
    {   

        [Required(ErrorMessage="Product Code")]
        public string ProductCode { get; set; }
        [Required(ErrorMessage = "Product name")]
        public string ProdName { get; set; }
        public string ProductBrand { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Product Category")]
        public string ProdCategory { get; set; }

        [Required(ErrorMessage = "Supplier Price")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> ProdPrice { get; set; }

        [Required(ErrorMessage = "Selling Price")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> ProdSellingPrice { get; set; }

        public string ProdUnitWght { get; set; }
        [Required(ErrorMessage = "Product Supplier")]
        public string ProdSuppID { get; set; }
        public string ProdStatus { get; set; }
        public string ProdCreateDate { get; set; }
        public HttpPostedFileWrapper Image { get; set; }
            
        public string Category { get; set; }      
        public string  Supplier { get; set; }

    }
}