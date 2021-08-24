using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM.Models.Classes;

namespace ATM.Controllers
{
	public class EvlerController : Controller
	{
		Context c = new Context();
		[Authorize]
		public ActionResult Index(string searching)
		{
			return View(c.Evler.Where(x => x.nameSurname.Contains(searching) || x.telephoneNo.Contains(searching) ||
			x.price.ToString() == searching || x.address.Contains(searching) || searching == null).ToList());
		}
		public ActionResult Details(int id = 0)
		{
			Ev ev = c.Evler.Find(id);
			kontrat kont = c.Kontrat.Where(x => x.evId == id).SingleOrDefault();
			List<Resim> resim = c.Resim.Where(x => x.evId == id).ToList();
			ViewData["Resimler"] = resim;
			ViewData["Kontrat"] = kont;
			return View(ev);
		}
		[HttpPost]
		public ActionResult Update(Ev ev)
		{
			var evler = c.Evler.Find(ev.ID);
			evler.nameSurname = ev.nameSurname;
			evler.price = ev.price;
			evler.telephoneNo = ev.telephoneNo;
			evler.address = ev.address;
			evler.metrekare = ev.metrekare;
			evler.not = ev.not;
			evler.bulunduguKat = ev.bulunduguKat;
			evler.binaKatSayisi = ev.binaKatSayisi;
			evler.odaSayisi = ev.odaSayisi;
			c.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DeletePhoto(int id = 0)
		{
			var resimler = c.Resim.Find(id);
			c.Resim.Remove(resimler);
			c.SaveChanges();
			return RedirectToAction("Details", new { id = resimler.evId });
		}
		public ActionResult DeleteContract(int id = 0)
		{
			kontrat kont = c.Kontrat.Where(x => x.evId == id).SingleOrDefault();
			c.Kontrat.Remove(kont);
			c.SaveChanges();
			return RedirectToAction("Details", new { id = kont.evId });
		}
		public ActionResult FileUpload(int id ,HttpPostedFileBase file)
		{
			string extension = System.IO.Path.GetExtension(file.FileName);
			if (file != null && !extension.Contains("pdf"))
			{
				string pic = System.IO.Path.GetFileName(file.FileName);
				string path = System.IO.Path.Combine(
									   Server.MapPath("~/Resimler/"), pic);
				
			
				int max = c.Resim.Max(p => p.ID);

				string localPath = "~/Resimler/";
				file.SaveAs(path);
				//ev id yi otomatik çek biryerlerden
				var resim = new Resim { ID = max+1 , imagePath = localPath+pic, evId = id };	
				c.Resim.Add(resim);
				c.SaveChanges();

				using (MemoryStream ms = new MemoryStream())
				{
					file.InputStream.CopyTo(ms);
					byte[] array = ms.GetBuffer();
				}
			}
			else if (file !=null && extension.Contains("pdf"))
			{
				string pic = System.IO.Path.GetFileName(file.FileName);
				string path = System.IO.Path.Combine(
									   Server.MapPath("~/Kontrat/"), pic);

				int max = c.Kontrat.Max(p => p.ID);

				string localPath = "~/Kontrat/";
				file.SaveAs(path);
				//ev id yi otomatik çek biryerlerden
				var kontrats = new kontrat { ID = max + 1,  kontratPath = localPath + pic, evId = id };
				c.Kontrat.Add(kontrats);
				c.SaveChanges();

				using (MemoryStream ms = new MemoryStream())
				{
					file.InputStream.CopyTo(ms);
					byte[] array = ms.GetBuffer();
				}
			}
			return RedirectToAction("Details",new { id = id });
		}
		public ActionResult EvEkle()
		{
			return RedirectToAction("Index", "EvEkle");
		}
	}
}