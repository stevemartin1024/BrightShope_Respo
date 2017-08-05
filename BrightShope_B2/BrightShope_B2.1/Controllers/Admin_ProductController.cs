using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrightShope_B2._1.Models;
using MVC5_Sample_LoginWithUserRole2.CustomFilters;
using BrightShope_B2._1.Controllers;
using System.IO;

namespace BrightShope_B2._1.Controllers
{
    public class Admin_ProductController : Controller
    {
        // GET: Admin_Product
        public ActionResult Product()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetListOfProduct()
        {
            BrightShoppeDBEntities db = new BrightShoppeDBEntities();

            List<ProductViewModel> productVMList = db.Products.Where(x => x.ProdStatus == "0").Select(x => new ProductViewModel{ 
                ProductCode = x.ProductCode,
                ProdName = x.ProdName,
                ProductBrand = x.ProductBrand,
                Category = x.Category.CategoryName,
                ProdPrice = x.ProdPrice,
                ProdSellingPrice = x.ProdSellingPrice,
                Supplier = x.Supplier.SuppName
                }).ToList();

            return Json(productVMList,JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreatNewProduct()
        {

            BrightShoppeDBEntities db = new BrightShoppeDBEntities();
            List<Category> categoryList = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(categoryList, "CategoryID", "CategoryName");

            List<Supplier> supplierList = db.Suppliers.ToList();
            ViewBag.SupplierList = new SelectList(supplierList, "SupplierID", "SuppName");

            return View();
        }

        [HttpPost]
        public ActionResult CheckProdCodeExist(string _productCode)
        {
            int result = 0;
            BrightShoppeDBEntities db = new BrightShoppeDBEntities();
            List<Product> itsExist = db.Products.Where(x => x.ProductCode == _productCode).ToList();
            if (itsExist != null && itsExist.Count >= 1)
            {
                result = 1;
            }
            return Json(result);
        }


        [HttpPost]
        public ActionResult createNewProduct(ProductViewModel m)
        {
               
               BrightShoppeDBEntities db = new BrightShoppeDBEntities();
               int result = 0;
               byte[] imagebyte = null;
               

                if(m.Image != null)
                {
                    var file = m.Image;
                    BinaryReader reader = new BinaryReader(file.InputStream);
                    imagebyte = reader.ReadBytes(file.ContentLength);
                }
              
               

                Product prod = new Product();
                
                prod.ProductCode = m.ProductCode;
                prod.ProdName = m.ProdName;
                prod.ProductBrand = m.ProductBrand;
                prod.Description = m.Description;
                prod.ProdCategory = m.ProdCategory;
                prod.ProdSuppID = m.ProdSuppID;
                prod.ProdPrice =  m.ProdPrice;
                prod.ProdSellingPrice = m.ProdSellingPrice;
                prod.ProdCreateDate = DateTime.Now.ToString("MM-dd-yyyy");
                prod.ProductImage = imagebyte;
                prod.ProdStatus = "0";
                
                db.Products.Add(prod);
                result = db.SaveChanges();



                return Json(result);
                //if(imagebyte != null)
                //{
                //    return Json(m.ProductCode);
                //}
                //else
                //{
                //    int x = 0;
                //    return Json(x);
                //}
                               
        }


        //public ActionResult imageRetrieve(string _prodCode)
        //{
        //    BrightShoppeDBEntities db = new BrightShoppeDBEntities();

        //    var img = db.Products.SingleOrDefault(x => x.ProductCode == _prodCode);

           
        //    return File(img.ProductImage, "image/jpg");
                
        //}


    }
}


