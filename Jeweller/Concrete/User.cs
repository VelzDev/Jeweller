using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Jeweller.Concrete
{
	public class User
	{
		public int Id { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Country { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public virtual ICollection<Cart> CartItems { get; set; }
		public virtual ICollection<Favorite> FavoriteItems { get; set; }
		public virtual ICollection<Sale> Sales { get; set; }
	}
}
