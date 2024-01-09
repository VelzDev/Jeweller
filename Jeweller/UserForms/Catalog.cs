using Jeweller.Concrete;
using Jeweller.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeweller
{
	public partial class Catalog : Form
	{
		private User current_user;
		public Catalog(User user)
		{
			this.current_user = user;
			InitializeComponent();
			DisplayProducts(LoadProductsFromDatabase());
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private List<Product> LoadProductsFromDatabase()
		{
			using (var context = new JewellerContext())
			{
				List<Product> products = context.Products.ToList();
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
				pictureBoxes[i].Image = GetImageFromByteArray(products[i].Image);
				pictureBoxes[i].Tag = products[i];
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

		private void корзинаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CartForm cartForm = new CartForm(current_user);
			cartForm.Show();

		}

		private void Catalog_Load(object sender, EventArgs e)
		{

		}

		private void избранноеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FavoritesCatalog catalog = new FavoritesCatalog(current_user);
			catalog.Show();
		}

		private void Catalog_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
