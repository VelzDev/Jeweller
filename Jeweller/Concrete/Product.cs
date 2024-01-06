using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Jeweller.Concrete
{
	public class Product
	{
		public int Id { get; set; }
		public byte[] Image { get; set; }
		public string Name { get; set; }
		public int QuantityInStock { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public int CategoryId { get; set; }

		public virtual Category Category { get; set; }
		public virtual ICollection<Cart> CartItems { get; set; }
		public virtual ICollection<Favorite> FavoriteItems { get; set; }
		public virtual ICollection<Sale> Sales { get; set; }
	}
}
