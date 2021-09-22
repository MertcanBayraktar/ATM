using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM.Models.Classes;

namespace ATM.Controllers
{
    public class KullaniciEkleController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciEkle(User user)
        {
            var x = new User();
            x.nameSurname = user.nameSurname;
            x.password = user.password;
            x.role = user.role;
            x.userName = user.userName;

            c.Users.Add(x);
            c.SaveChanges();
            return RedirectToAction("Index","User");
        }
    }
}