using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeweller.Concrete
{
	public class Sale
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int UserId { get; set; }
		public string PaymentMethod { get; set; }
		public string CreditCardNumber { get; set; }
		public string ExpiryDate { get; set; }
		public string CardType { get; set; }
		public string Cvc { get; set; }

		public virtual User User { get; set; }
		public virtual Product Product { get; set; }
	}
}
