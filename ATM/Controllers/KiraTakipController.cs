using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM.Models.Classes;
namespace ATM.Controllers
{
    public class KiraTakipController : Controller
    {
        Context c = new Context();
		public ActionResult Index(string searching)
		{
			var myStr = Session["Name"] as String;
			return View(c.Evler.Where(x => x.nameSurname == myStr).ToList());
		}
		public ActionResult Details(int id = 0)
		{
			KiraTakip kiratakip = c.KiraTakip.Find(id);
			kontrat kont = c.Kontrat.Where(x => x.evId == id).SingleOrDefault();
			List<Resim> resim = c.Resim.Where(x => x.evId == id).ToList();
			ViewData["Resimler"] = resim;
			ViewData["Kontrat"] = kont;
			return View(kiratakip);
		}
	}
}