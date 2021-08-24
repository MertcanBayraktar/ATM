using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATM.Models.Classes
{
	public class Ev
	{
		[Key]
		public int ID { get; set; }
		public string nameSurname { get; set; }
		public string address { get; set; }
		public string telephoneNo { get; set; }
		public float price { get; set; }
		public int metrekare { get; set; }
		public int odaSayisi { get; set; }
		public string not { get; set; }
		public int binaKatSayisi { get; set; }
		public int bulunduguKat { get; set; }
		public Resim resim { get; set; }
	}
}