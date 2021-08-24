using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATM.Models.Classes
{
	public class Alici
	{
		[Key]
		public int ID { get; set; }
		public string nameSurname { get; set; }
		public string locations { get; set; }
		public float priceMin { get; set; }
		public float priceMax { get; set; }
		public string not { get; set; }
		public string telephoneNo { get; set; }
		public bool isActive { get; set; }
	}
}