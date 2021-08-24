using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ATM.Models.Classes;
namespace ATM.Controllers
{
    public class LoginController : Controller
    {

        Context c = new Context();
        [AllowAnonymous]
        public ActionResult Index(User user)
        {
            var u = c.Users.FirstOrDefault(x => x.userName == user.userName && x.password == user.password);
            if(u != null)
			{               
                FormsAuthentication.SetAuthCookie(u.userName,false);
                Session["Role"] = u.role;
                Session["Name"] = u.nameSurname;             
                if (u.role == "admin" || u.role == "user")
                {
                    return RedirectToAction("Index", "Evler");
                }
				else
				{
                    return RedirectToAction("Index", "KiraTakip");
				}
			}
			else
			{
                // yanlış değer girilmiş
                ViewBag.LoginError = "Hatalı kullanıcı adı veya şifre";
			}
            return View();
        }
        public ActionResult LogOut()
		{
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
		}
    }
}