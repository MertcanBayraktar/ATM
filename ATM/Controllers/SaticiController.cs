using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM.Models.Classes;
namespace ATM.Controllers
{
    public class SaticiController : Controller
    {
        Context c = new Context();
        public ActionResult Index(string searching)
        {
            return View(c.Saticilar.Where(x => x.nameSurname.Contains(searching) || x.telephoneNo.Contains(searching) ||
            x.priceMin.ToString().Contains(searching) || x.priceMax.ToString().Contains(searching) || x.not.Contains(searching) || x.adress.Contains(searching) ||searching == null).ToList());
        }
        public ActionResult SaticiEkle()
        {
            return RedirectToAction("Index", "SaticiEkle");
        }
        public ActionResult Details(int id = 0)
        {
            Satici satici = c.Saticilar.Find(id);
            return View(satici);
        }
        [HttpPost]
        public ActionResult Update(Satici satici)
        {
            var saticilar = c.Saticilar.Find(satici.ID);
            saticilar.nameSurname = satici.nameSurname;
            saticilar.priceMax = satici.priceMax;
            saticilar.priceMin = satici.priceMin;
            saticilar.adress = satici.adress;
            saticilar.not = satici.not;
            saticilar.telephoneNo = satici.telephoneNo;
            saticilar.isActive = satici.isActive;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}