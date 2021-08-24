using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM.Models.Classes;
namespace ATM.Controllers
{
    public class SaticiEkleController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaticiEkle(Satici satici)
		{
            c.Saticilar.Add(new Satici
            {
                adress = satici.adress,
                isActive = satici.isActive,
                nameSurname = satici.nameSurname,
                not = satici.not,
                priceMax = satici.priceMax,
                priceMin = satici.priceMin,
                telephoneNo = satici.telephoneNo,
            }) ;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}