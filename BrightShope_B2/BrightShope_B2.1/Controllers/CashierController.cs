using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrightShope_B2._1.Controllers
{   
    [Authorize(Roles="Cashier")]
    public class CashierController : Controller
    {
        // GET: Cashier
        public ActionResult Index()
        {
            return View();
        }
    }
}