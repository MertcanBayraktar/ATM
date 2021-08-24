using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace ATM.Models.Classes
{
	public class Context:DbContext
	{
		public DbSet<KiraTakip> KiraTakip { get; set; }
		public DbSet<Alici> Alicilar { get; set; }
		public DbSet<Ev> Evler { get; set; }
		public DbSet<Satici> Saticilar { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Resim> Resim { get; set; }
		public DbSet<kontrat> Kontrat { get; set; }
	}
}