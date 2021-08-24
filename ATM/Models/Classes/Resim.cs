using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATM.Models.Classes
{
	public class Resim
	{
		[Key]
		public int ID { get; set; }
		public int evId { get; set; }
		public string imagePath { get; set; }
	}
}