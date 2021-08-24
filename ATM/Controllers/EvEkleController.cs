using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM.Models.Classes;
namespace ATM.Controllers
{
    public class EvEkleController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
           
			return View();
        }
        [HttpPost]
        public ActionResult EvEkle(Ev ev)
		{
            var x = new Ev();
            x.nameSurname = ev.nameSurname;
            x.address = ev.address;
            x.binaKatSayisi = ev.binaKatSayisi;
            x.bulunduguKat = ev.bulunduguKat;
            x.metrekare = ev.metrekare;
            x.not = ev.not;
            x.odaSayisi = ev.odaSayisi;
            x.price = ev.price;
            x.telephoneNo = ev.telephoneNo;

            c.Evler.Add(x);
            c.SaveChanges();
            c.Entry(x).GetDatabaseValues();
			c.KiraTakip.Add(new KiraTakip
			{
				nameSurname = x.nameSurname,
				evId = x.ID
			});
			c.SaveChanges();
			return RedirectToAction("Index");
		}
    }
}