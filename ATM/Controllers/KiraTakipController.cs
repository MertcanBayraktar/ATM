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
		public ActionResult Details(FormCollection collection, int id = 0)
		{
			KiraTakip kiratakip = c.KiraTakip.Where(p => p.evId == id).FirstOrDefault();
			kontrat kont = c.Kontrat.Where(x => x.evId == id).SingleOrDefault();
			List<Resim> resim = c.Resim.Where(x => x.evId == id).ToList();
			Ev ev = c.Evler.Where(x => x.ID == id).SingleOrDefault();
			ViewBag.kira = ev.price;
			ViewData["Resimler"] = resim;
			ViewData["Kontrat"] = kont;
			return View(kiratakip);
		}
		[HttpPost]
		public ActionResult Update(FormCollection collection, int id = 0)
		{
			var valueOcak = collection["Ocak"];
			valueOcak = valueOcak.Split(',')[0];

			var valueSubat = collection["Subat"];
			valueSubat = valueSubat.Split(',')[0];

			var valueMart = collection["Mart"];
			valueMart = valueMart.Split(',')[0];

			var valueNisan = collection["Nisan"];
			valueNisan = valueNisan.Split(',')[0];

			var valueMayis = collection["Mayis"];
			valueMayis = valueMayis.Split(',')[0];

			var valueHaziran = collection["Haziran"];
			valueHaziran = valueHaziran.Split(',')[0];

			var valueTemmuz = collection["Temmuz"];
			valueTemmuz = valueTemmuz.Split(',')[0];

			var valueAgustos = collection["Agustos"];
			valueAgustos = valueAgustos.Split(',')[0];

			var valueEylul = collection["Eylul"];
			valueEylul = valueEylul.Split(',')[0];

			var valueEkim = collection["Ekim"];
			valueEkim = valueEkim.Split(',')[0];

			var valueKasim = collection["Kasim"];
			valueKasim = valueKasim.Split(',')[0];

			var valueAralik = collection["Aralik"];
			valueAralik = valueAralik.Split(',')[0];

			var kiratakip = c.KiraTakip.Find(id);
			kiratakip.Ocak = bool.Parse(valueOcak);
			kiratakip.Subat = bool.Parse(valueSubat);
			kiratakip.Mart = bool.Parse(valueMart);
			kiratakip.Nisan = bool.Parse(valueNisan);
			kiratakip.Mayis = bool.Parse(valueMayis);
			kiratakip.Haziran = bool.Parse(valueHaziran);
			kiratakip.Temmuz = bool.Parse(valueTemmuz);
			kiratakip.Agustos = bool.Parse(valueAgustos);
			kiratakip.Eylul = bool.Parse(valueEylul);
			kiratakip.Ekim = bool.Parse(valueEkim);
			kiratakip.Kasim = bool.Parse(valueKasim);
			kiratakip.Aralik = bool.Parse(valueAralik);
			c.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}