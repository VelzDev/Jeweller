using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jeweller.Concrete
{
	public class CartItemViewModel
	{
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
