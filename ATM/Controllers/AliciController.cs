using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM.Models.Classes;
namespace ATM.Controllers
{

    public class AliciController : Controller
    {
        Context c = new Context();
        public ActionResult Index(string searching)
        {
            return View(c.Alicilar.Where(x => x.nameSurname.Contains(searching) || x.telephoneNo.Contains(searching) ||
      x.priceMin.ToString().Contains(searching) || x.priceMax.ToString().Contains(searching) || x.locations.Contains(searching) || searching == null).ToList());
        }
        [HttpPost]
        public ActionResult AliciEkle()
		{
            return RedirectToAction("Index", "AliciEkle");
        }
        public ActionResult Details(int id = 0)
        {
            Alici alici = c.Alicilar.Find(id);
            return View(alici);
        }
        [HttpPost]
        public ActionResult Update(Alici alici)
        {
            var alicilar = c.Alicilar.Find(alici.ID);
            alicilar.nameSurname = alici.nameSurname;
            alicilar.priceMax = alici.priceMax;
            alicilar.priceMin = alici.priceMin;
            alicilar.telephoneNo = alici.telephoneNo;
            alicilar.not = alici.telephoneNo;
            alicilar.isActive = alici.isActive;
            alicilar.locations = alici.locations;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}