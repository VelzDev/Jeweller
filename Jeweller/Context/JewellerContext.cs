using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeweller.Concrete;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Runtime.Remoting.Contexts;

namespace Jeweller.Context
{

	public class YourDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<FavoriteItem> FavoriteItems { get; set; }
		public DbSet<Sale> Sales { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// Указать строку подключения к вашей базе данных
			optionsBuilder.UseSqlServer("YourConnectionString");
		}
	}
}
