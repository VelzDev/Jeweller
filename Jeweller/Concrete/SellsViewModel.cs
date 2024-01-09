using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeweller.Concrete
{
	internal class SellsViewModel
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
		public string UserName { get; set; }
		public DateTime SaleDate { get; set; }
		public decimal TotalPrice { get; set; }
		public string PaymentMethod { get; set; }
		public string CreditCardNumber { get; set; }
		public string ExpiryDate { get; set; }
		public string CardType { get; set; }
		public string Cvc { get; set; }
	}
}
