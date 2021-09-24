using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM.Models.Classes;
namespace ATM.Controllers
{
	public class AliciEkleController : Controller
	{
		Context c = new Context();
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AliciEkle(Alici alici)
		{
			c.Alicilar.Add(new Alici
			{
				nameSurname = alici.nameSurname,
				locations = alici.locations,
				priceMin = alici.priceMin,
				priceMax = alici.priceMax,
				not = alici.not,
				telephoneNo = alici.telephoneNo,
				isActive = alici.isActive,
			});
			c.SaveChanges();
			return RedirectToAction("Index","Alici");
		}
	}
}