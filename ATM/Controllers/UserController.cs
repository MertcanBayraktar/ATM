using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM.Models.Classes;


namespace ATM.Controllers
{
    public class UserController : Controller
    {
       
        Context c = new Context();
        [Authorize]
        public ActionResult Index(string searching)
        {
            return View(c.Users.Where(x => x.nameSurname.Contains(searching) || x.password.Contains(searching) ||
            x.role.ToString() == searching || x.userName.Contains(searching) || searching == null).ToList());
        }
        public ActionResult KullaniciEkle()
        {
            return RedirectToAction("Index", "KullaniciEkle");
        }
        public ActionResult Details(int id = 0)
        {
            User user = c.Users.Find(id);
            return View(user);
        }
        public ActionResult Update(User user)
        {
            var users = c.Users.Find(user.ID);
            users.nameSurname = user.nameSurname;
            users.password = user.password;
            users.userName = user.userName;
            users.role = user.role;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}