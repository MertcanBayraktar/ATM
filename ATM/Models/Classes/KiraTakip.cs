using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATM.Models.Classes
{
	public class KiraTakip
	{
		[Key]
		public int ID { get; set; }
		public string nameSurname { get; set; }
		public int evId { get; set; }
		public bool Ocak { get; set; }
		public bool Subat { get; set; }
		public bool Mart { get; set; }
		public bool Nisan { get; set; }
		public bool Mayis { get; set; }
		public bool Haziran { get; set; }
		public bool Temmuz { get; set; }
		public bool Agustos { get; set; }
		public bool Eylul { get; set; }
		public bool Ekim { get; set; }
		public bool Kasim { get; set; }
		public bool Aralik { get; set; }
	}
}