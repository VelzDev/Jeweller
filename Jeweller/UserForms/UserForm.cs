using System;
using Jeweller.Concrete;
using Jeweller.Context;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Jeweller
{
	public partial class UserForm : Form
	{
		private User current_user;
		private Product product;
		public UserForm(Product product, User user)
		{
			InitializeComponent();
			this.current_user = user;
			this.product = product;
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

			using (var context = new JewellerContext())
			{
				var updatedProduct = context.Products.FirstOrDefault(p => p.Id == product.Id);
				if (updatedProduct != null)
				{
					label4.Text = updatedProduct.Price.ToString();
					label2.Text = updatedProduct.QuantityInStock.ToString();
					textBox2.Text = updatedProduct.Description;
					label6.Text = updatedProduct.Name;
					pictureBox1.Image = GetImageFromByteArray(updatedProduct.Image);
				}
			}
			

			using (var context = new JewellerContext())
			{
				// Проверка наличия элемента в избранном для текущего пользователя
				var existingFavorite = context.FavoriteItems
					.SingleOrDefault(f => f.UserId == current_user.Id && f.ProductId == product.Id);

				if (existingFavorite != null)
				{
					button2.Text = "Добавить в избранное";
				}
				else
				{
					button2.Text = "Убрать из избранного";
				}
				context.SaveChanges(); // Сохранить изменения в базе данных
			}
		}

		public static Image GetImageFromByteArray(byte[] byteArray)
		{
			if (byteArray == null || byteArray.Length == 0)
				return null;

			try
			{
				using (MemoryStream memoryStream = new MemoryStream(byteArray))
				{
					Image image = Image.FromStream(memoryStream);
					return image;
				}
			}
			catch (Exception ex)
			{
				// Обработка ошибок (например, логирование или возврат значения по умолчанию)
				Console.WriteLine("Ошибка при преобразовании изображения из массива байтов: " + ex.Message);
				return null;
			}
		}
		private int quantity;
		private void button1_Click(object sender, EventArgs e)
		{
			using (var dialog = new InputBox())
			{
				dialog.ShowDialog();
				int selectedNumber = dialog.SelectedNumber;
				this.quantity= selectedNumber;
			}

			using (var context = new JewellerContext())
			{

				if (!(quantity == 0 && quantity < product.QuantityInStock))
				{
					// Создать корзину и добавить в нее продукт
					Cart cart = new Cart()
					{
						UserId = current_user.Id,
						ProductId = product.Id,
						Quantity = quantity,
						TotalPrice = product.Price * quantity,
					};

					context.CartItems.Add(cart);
					context.SaveChanges(); // Сохранить изменения в базе данных
				}
				else MessageBox.Show("Такого количества нет в наличии");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (var context = new JewellerContext())
			{
				// Проверка наличия элемента в избранном для текущего пользователя
				var existingFavorite = context.FavoriteItems
					.SingleOrDefault(f => f.UserId == current_user.Id && f.ProductId == product.Id);

				if (existingFavorite != null)
				{
					// Если элемент уже существует в избранном, удалить его
					context.FavoriteItems.Remove(existingFavorite);
					button2.Text = "Добавить в избранное";
				}
				else
				{
					// Иначе, добавить новый элемент в избранное
					Favorite favorite = new Favorite()
					{
						UserId = current_user.Id,
						ProductId = product.Id,
					};
					context.FavoriteItems.Add(favorite);
					button2.Text = "Убрать из избранного";
				}

				context.SaveChanges(); // Сохранить изменения в базе данных
			}
		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}
	}
}
