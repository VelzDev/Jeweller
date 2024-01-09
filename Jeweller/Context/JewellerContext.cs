using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeweller.Concrete;
//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;

namespace Jeweller.Context
{
	[DbConfigurationType(typeof(DbConfiguration))]
	public class JewellerContext : System.Data.Entity.DbContext
	{
		public JewellerContext() : base("YourConnectionStringName")
		{

		}
		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Cart> CartItems { get; set; }
		public DbSet<Favorite> FavoriteItems { get; set; }
		public DbSet<Sale> Sales { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Ваши настройки модели
		}
	}
}
