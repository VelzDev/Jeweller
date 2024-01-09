using System;
using Jeweller.Concrete;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jeweller.Context;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Jeweller
{
	public partial class CartForm : Form
	{
		private User current_user;
		private decimal price = 0;
		public CartForm(User user)
		{
			InitializeComponent();
			this.current_user = user;
			using (var context = new JewellerContext())
			{
				// Получение данных из CartItems для текущего пользователя с информацией о продукте
				var userCartItems = context.CartItems
					.Where(c => c.UserId == current_user.Id)
					.Select(c => new CartItemViewModel
					{
						ProductName = c.Product.Name, // Поле для отображения имени продукта
						Quantity = c.Quantity,
						TotalPrice = c.TotalPrice
					})
					.ToList();
				foreach (var item in userCartItems)
				{
					price += item.TotalPrice;
				}
				// Привязка данных к DataGridView
				dataGridView1.DataSource = userCartItems;
				label2.Text = price.ToString();
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			using (var context = new JewellerContext())
			{
				var userCartItems = context.CartItems
					.Where(c => c.UserId == current_user.Id)
					.ToList();
				if (radioButton3.Checked)
				{
					using (var dialog = new PaymentBox())
					{
						dialog.ShowDialog();
						foreach (var cartItem in userCartItems)
						{
							Sale sale = new Sale
							{
								ProductId = cartItem.ProductId,
								UserId = cartItem.UserId,
								PaymentMethod = GetSelectedPaymentMethod(), // Получаем выбранный способ оплаты
								SaleDate = DateTime.Now,
								TotalPrice = cartItem.TotalPrice,
								CreditCardNumber = dialog.cardNumber,
								ExpiryDate = dialog.expDate,
								CardType = dialog.type,
								Cvc = dialog.CVC,
							};

							context.Sales.Add(sale);
							var product = context.Products.Find(cartItem.ProductId);
							if (product != null)
							{
								product.QuantityInStock -= cartItem.Quantity;
							}
						}
					}
				}
				else
				{
					foreach (var cartItem in userCartItems)
					{
						Sale sale = new Sale
						{
							ProductId = cartItem.ProductId,
							UserId = cartItem.UserId,
							PaymentMethod = GetSelectedPaymentMethod(), // Получаем выбранный способ оплаты
							SaleDate = DateTime.Now,                                            // Добавьте другие необходимые данные для продажи
						};

						context.Sales.Add(sale);
						var product = context.Products.Find(cartItem.ProductId);
						if (product != null)
						{
							product.QuantityInStock -= cartItem.Quantity;
						}
					}
				}

				context.SaveChanges(); 
				context.CartItems.RemoveRange(userCartItems);
				context.SaveChanges(); 

				MessageBox.Show("Payment successful!");
			}
			this.Close();
		}

		private string GetSelectedPaymentMethod()
		{
			if (radioButton1.Checked)
			{
				return "Наличные";
			}
			else if (radioButton2.Checked)
			{
				return "Безнал";
			}
			else if (radioButton3.Checked)
			{
				return "Онлайн";
			}
			// Добавьте другие способы оплаты, если необходимо

			return string.Empty; // Если ничего не выбрано
		}

		private void CartForm_Load(object sender, EventArgs e)
		{
			using (var context = new JewellerContext())
			{
				// Получение данных из CartItems для текущего пользователя с информацией о продукте
				var userCartItems = context.CartItems
					.Where(c => c.UserId == current_user.Id)
					.Select(c => new CartItemViewModel
					{
						ProductName = c.Product.Name, // Поле для отображения имени продукта
						Quantity = c.Quantity,
						TotalPrice = c.TotalPrice
					})
					.ToList();

				// Привязка данных к DataGridView
				dataGridView1.DataSource = userCartItems;
			}
		}
	}
}
