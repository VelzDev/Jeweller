using Jeweller.Concrete;
using Jeweller.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeweller.AdminForms
{
	public partial class SalesViewForm : Form
	{
		public SalesViewForm()
		{
			InitializeComponent();
			using (var context = new JewellerContext())
			{
				// Получение данных из CartItems для текущего пользователя с информацией о продукте
				var userSaleItems = context.Sales
					.Select(c => new SellsViewModel
					{
						Id = c.Id,
						ProductName = c.Product.Name,
						UserName = c.User.Username,
						SaleDate = c.SaleDate,
						TotalPrice= c.TotalPrice,
						PaymentMethod = c.PaymentMethod,
						CreditCardNumber= c.CreditCardNumber,
						CardType= c.CardType,
						ExpiryDate	= c.ExpiryDate,
						Cvc = c.Cvc,
					})
					.ToList();

				// Привязка данных к DataGridView
				dataGridView1.DataSource = userSaleItems;
			}
		}

		private void SalesViewForm_Load(object sender, EventArgs e)
		{
			
		}
	}
}
