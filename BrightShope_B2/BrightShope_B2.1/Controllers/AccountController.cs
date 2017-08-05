using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BrightShope_B2._1.Models;
using System.Web.Security;
using MVC5_Sample_LoginWithUserRole2.CustomFilters;



namespace BrightShope_B2._1.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            string Email = Respository._UserName;
            _Logs_Logout(Email);
            Respository._UserName = null;
            Respository._Password = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {

                ViewBag.ReturnUrl = returnUrl;
                return View();      
               
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserLogin model, string returnUrl)
        {   
     
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                UserLogin _userCredential = new UserLogin() { Email = model.Email, Password = model.Password };

                _userCredential = Respository.GetUserDetails(_userCredential);

                if (_userCredential != null)
                {

                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    var authTicket = new FormsAuthenticationTicket(1, _userCredential.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, _userCredential.Roles);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);


                    if (returnUrl != null)
                    {
                        _fillRespository(model);
                        _Logs_Login(model.Email);
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        _fillRespository(model);
                        _Logs_Login(model.Email);
                        return RedirectToAction("Index", _userCredential.Roles);

                    }

                }
                else
                {

                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }
            
           
        }       
   

        private void _Logs_Login (string _userName)
        {

            BrightShoppeDBEntities db = new BrightShoppeDBEntities();
            Log _loginUser = new Log();
            _loginUser.Email = _userName;
            _loginUser.ProcessID = "1";
            _loginUser.value1 = null;
            _loginUser.DateTime = DateTime.Now.ToString();


            db.Logs.Add(_loginUser);
            db.SaveChanges();
        }


        private void _Logs_Logout(string _userName)
        {

            BrightShoppeDBEntities db = new BrightShoppeDBEntities();
            Log _loginUser = new Log();
            _loginUser.Email = _userName;
            _loginUser.ProcessID = "2";
            _loginUser.value1 = null;
            _loginUser.DateTime = DateTime.Now.ToString();


            db.Logs.Add(_loginUser);
            db.SaveChanges();
        }


        private void _fillRespository(UserLogin model)
        {
            Respository._UserName = model.Email;
            Respository._Password = model.Password;
            Respository._Role = model.Roles;
        }
    }
}