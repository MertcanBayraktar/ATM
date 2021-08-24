using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATM.Models.Classes
{
	public class User
	{
		[Key]
		public int ID { get; set; }
		public string nameSurname { get; set; }
		public string userName { get; set; }
		public string password { get; set; }
		public string role { get; set; }
	}
}