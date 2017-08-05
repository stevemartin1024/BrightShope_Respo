using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrightShope_B2._1.Models;
using MVC5_Sample_LoginWithUserRole2.CustomFilters;
using BrightShope_B2._1.Controllers;

namespace BrightShope_B1.Controllers
{

    [AuthLog(Roles = "Admin")]
    public class AdminController : Controller
    {
   
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Supplier()
        {
     
            return View();
        }

        [HttpGet]
        public ActionResult GetSuppliersData()
        {

            BrightShoppeDBEntities BSDB = new BrightShoppeDBEntities();
            List<Supplier> supplierList = BSDB.Suppliers.ToList();

            List<supplierViewModel> listSVM = supplierList.Where(SVM => SVM.SuppStatus == "0").Select(SVM => new supplierViewModel
            {
                SupplierID = SVM.SupplierID,
                SuppName = SVM.SuppName,
                SuppContact_ = SVM.SuppContact_,
                SuppEmail = SVM.SuppEmail
            }).ToList();
            return Json(listSVM,JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GenerateSupplierID()
        {
            using (var context = new BrightShoppeDBEntities())
            {
                string myquery = "select max(SupplierID) FROM Supplier";
                var getMaxSupplierId = context.Database.SqlQuery<string>(myquery).FirstOrDefault();

                string _getEndNumber = getMaxSupplierId.ToString().Substring(4, 4);

                int _incEndNumber = Convert.ToInt32(_getEndNumber) + 1;
                string _GenerateSuppID = "SUPP" + _incEndNumber.ToString("D4");
                return Json(_GenerateSuppID, JsonRequestBehavior.AllowGet);
            }     
        }


        [HttpPost]
        public ActionResult InsertNewSupplier(supplierViewModel _suppViewModel)
        {
            try
            {
                BrightShoppeDBEntities BSDB = new BrightShoppeDBEntities();

                Supplier svm = new Supplier();

                svm.SupplierID = _suppViewModel.SupplierID;
                svm.SuppName = _suppViewModel.SuppName;
                svm.SuppAddress = _suppViewModel.SuppAddress;
                svm.SuppCity_Prov = _suppViewModel.SuppCity_Prov;
                svm.SuppContact_ = _suppViewModel.SuppContact_;
                svm.SuppEmail = _suppViewModel.SuppEmail;
                svm.SuppRemarks = _suppViewModel.SuppRemarks;
                svm.SuppStatus = "ACTIVE";

                BSDB.Suppliers.Add(svm);
                BSDB.SaveChanges();
            }
            catch
            {
                
            }

            _Logs(Respository._UserName, "3", _suppViewModel.SupplierID);
            return Json(_suppViewModel);
           
        }



        [HttpPost]
        public ActionResult UpdateSupplier(supplierViewModel _suppViewModel)
        {
            try
            {
                BrightShoppeDBEntities BSDB = new BrightShoppeDBEntities();

               Supplier svm = BSDB.Suppliers.SingleOrDefault( m => m.SupplierID == _suppViewModel.SupplierID);
            
                if(svm != null)
                {
                      svm.SuppName = _suppViewModel.SuppName;
                      svm.SuppAddress = _suppViewModel.SuppAddress;
                      svm.SuppCity_Prov = _suppViewModel.SuppCity_Prov;
                      svm.SuppContact_ = _suppViewModel.SuppContact_;
                      svm.SuppEmail = _suppViewModel.SuppEmail;
                      svm.SuppStatus = "ACTIVE";
                      BSDB.SaveChanges();
                }
              
                
            }
            catch
            {
                throw;
            }

            _Logs(Respository._UserName, "4", _suppViewModel.SupplierID);
            return Json(_suppViewModel);


        }


        [HttpPost]
        public ActionResult MarkDeleteSupplier(string supplierID)
        {   
            int result = 0;
            BrightShoppeDBEntities BSDB = new BrightShoppeDBEntities();
            Supplier suppDetails = BSDB.Suppliers.Where(x => x.SupplierID == supplierID).Single();
            
            if(suppDetails != null)
            {
                suppDetails.SuppStatus = "1";
                result = BSDB.SaveChanges();
                _Logs(Respository._UserName, "5", supplierID);
            }
  
            return Json(result);
        }

        [HttpPost]
        public ActionResult ConfirmPassword(string _userPassword)
        {
            int result = 0;
            if(Respository._Password == _userPassword)
            {
                result = 1;
            }

            return Json(result);
        }


        [HttpPost]
        public ActionResult GetSupplierDetails(string supplierID)
        {
             BrightShoppeDBEntities BSDB = new BrightShoppeDBEntities();
             Supplier suppDetails = BSDB.Suppliers.Where(x => x.SupplierID == supplierID).Single();
             supplierViewModel svm = new supplierViewModel();
             if(suppDetails != null)
             {  
                 svm.SuppName = suppDetails.SuppName;
                 svm.SuppAddress = suppDetails.SuppAddress;
                 svm.SuppCity_Prov = suppDetails.SuppCity_Prov;
                 svm.SuppContact_ = suppDetails.SuppContact_;
                 svm.SuppEmail = suppDetails.SuppEmail;                 
             }
             return Json(svm);
        }


        private void _Logs(string userEmail, string processId, string Value)
        {
            BrightShoppeDBEntities db = new BrightShoppeDBEntities();
            Log adminLog = new Log();
            adminLog.ProcessID = processId;
            adminLog.DateTime = DateTime.Now.ToString();
            adminLog.value1 = Value;
            adminLog.Email = userEmail;
            db.Logs.Add(adminLog);
            db.SaveChanges();

        }
    }
}