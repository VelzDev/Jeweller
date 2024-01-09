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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Jeweller.AdminForms
{
	public partial class ProductEditForm : Form
	{
		private Product product;
		public ProductEditForm(Product product)
		{
			InitializeComponent();
			this.product = product;
			pictureBox1.SizeMode=PictureBoxSizeMode.Zoom;
			pictureBox1.Image = GetImageFromByteArray(product.Image);
			textBox2.Text = product.Description;
			textBox3.Text = product.Price.ToString();
			textBox4.Text = product.QuantityInStock.ToString();
			textBox5.Text = product.Name;
		}
		private Image image;
		private void button3_Click(object sender, EventArgs e)
		{
			using (var context = new JewellerContext())
			{
				Product productToUpdate = context.Products.FirstOrDefault(u => u.Id == product.Id);
				if (!(textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && image == null))
				{
					if (productToUpdate!= null) {
						productToUpdate.Image = ImageToByteArray(image);
						productToUpdate.Name = textBox5.Text;
						productToUpdate.QuantityInStock = Convert.ToInt32(textBox4.Text);
						productToUpdate.Price = Convert.ToDecimal(textBox3.Text);
						productToUpdate.Description = textBox2.Text;

						context.SaveChanges(); // Сохранить изменения в базе данных
						MessageBox.Show("Success");
					}
				}
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
		private byte[] ImageToByteArray(Image image)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				// Преобразование изображения в массив байтов
				image.Save(memoryStream, image.RawFormat);
				return memoryStream.ToArray();
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.jpeg; *.gif; *.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					// Получаем путь к выбранному файлу
					string imagePath = openFileDialog.FileName;

					image = Image.FromFile(imagePath);
				}
			}
			pictureBox1.Image= image;
		}
	}
}
