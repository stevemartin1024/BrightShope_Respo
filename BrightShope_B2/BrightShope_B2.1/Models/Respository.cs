using BrightShope_B2._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrightShope_B2._1.Controllers
{
    public class Respository
    {
        public static string _UserName { get; set; }
        public static string _Password { get; set; }
        public static string _Role { get; set; }

        public static UserLogin GetUserDetails(UserLogin _userLogin)
        {
            BrightShoppeDBEntities db = new BrightShoppeDBEntities();
            List<User> Users = db.Users.ToList();
            UserLogin userlogin = new UserLogin();

            User _UserCrendeniial = Users.Where(u => u.Email.ToLower() == _userLogin.Email.ToLower() &&
            u.Password == _userLogin.Password).SingleOrDefault();

            if(_UserCrendeniial != null)
            {
                userlogin.Email = _UserCrendeniial.Email;
                userlogin.Password = _UserCrendeniial.Password;
                userlogin.Roles = _UserCrendeniial.Level;

                return userlogin;
            }
            else
            {
     
                return null;
            }
      
        }

    }
}