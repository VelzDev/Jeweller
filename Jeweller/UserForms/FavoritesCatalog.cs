using Jeweller.Concrete;
using Jeweller.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeweller
{
	public partial class FavoritesCatalog : Form
	{
		private User current_user;
		public FavoritesCatalog(User user)
		{
			this.current_user = user;
			InitializeComponent();
			DisplayProducts(LoadProductsFromDatabase());
		}
		private List<Product> LoadProductsFromDatabase()
		{
			using (var context = new JewellerContext())
			{
				// Получаем избранные продукты для текущего пользователя
				List<int> productIds = context.FavoriteItems
											.Where(favorite => favorite.UserId == current_user.Id)
											.Select(favorite => favorite.ProductId)
											.ToList();

				// Получаем информацию о продуктах по их Id
				List<Product> products = context.Products
											   .Where(product => productIds.Contains(product.Id))
											   .ToList();

				return products;
			}
		}

		private PictureBox[] pictureBoxes; // Объявление массива PictureBox

		private void InitializePictureBoxes()
		{
			pictureBoxes = new PictureBox[LoadProductsFromDatabase().Count]; // 15 товаров на странице
			const int padding = 10; // Отступ между PictureBox

			for (int i = 0; i < pictureBoxes.Length; i++)
			{
				pictureBoxes[i] = new PictureBox();
				pictureBoxes[i].Width = 100;
				pictureBoxes[i].Height = 100;

				int row = i / 5; // Вычисляем текущий ряд (0, 1, 2...)
				int column = i % 5; // Вычисляем текущий столбец в ряду (0, 1, 2, 3, 4)

				pictureBoxes[i].Location = new Point(20 + column * (pictureBoxes[i].Width + padding),
													 20 + row * (pictureBoxes[i].Height + padding));

				pictureBoxes[i].Click += PictureBox_Click;
				this.Controls.Add(pictureBoxes[i]); // Добавление PictureBox на форму
			}
		}
		private void PictureBox_Click(object sender, EventArgs e)
		{
			PictureBox pictureBox = (PictureBox)sender;
			Product selectedProduct = (Product)pictureBox.Tag;

			UserForm detailsForm = new UserForm(selectedProduct, current_user);
			detailsForm.Show();
		}

		private void DisplayProducts(List<Product> products)
		{
			InitializePictureBoxes();
			for (int i = 0; i < products.Count && i < pictureBoxes.Length; i++)
			{
				pictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
				// Устанавливаем изображение для PictureBox
				pictureBoxes[i].Image = GetImageFromByteArray(products[i].Image);
				pictureBoxes[i].Tag = products[i]; // Привязываем объект Product к PictureBox
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
		private void FavoritesCatalog_Load(object sender, EventArgs e)
		{

		}
	}
}
