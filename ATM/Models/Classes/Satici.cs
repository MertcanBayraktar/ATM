using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATM.Models.Classes
{
	public class Satici
	{
		[Key]
		public int ID { get; set; }
		public string nameSurname { get; set; }
		public float priceMin { get; set; }
		public float priceMax { get; set; }
		public string adress { get; set; }
		public string telephoneNo { get; set; }
		public string not { get; set; }
		public bool isActive { get; set; }
	}
}