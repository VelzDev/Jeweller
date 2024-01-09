using Jeweller.AdminForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Jeweller
{
	
	public partial class ProductViewForm : Form
	{
		public ProductViewForm()
		{
			InitializeComponent();
			using (var context = new JewellerContext()) // Замените YourDbContext на ваш класс контекста базы данных
			{
				var categories = context.Categories.ToList();

				comboBox1.Items.Clear();

				foreach (var category in categories)
				{
					var item = new CategoryItem
					{
						Id = category.Id,
						Name = category.Name
					};

					comboBox1.Items.Add(item);
				}

				comboBox1.DisplayMember = "Name";
				comboBox1.ValueMember = "Id";
			}
		}

		private Image image;

		private void ViewForm_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "jewellerShopDataSet4.Products". При необходимости она может быть перемещена или удалена.
			this.productsTableAdapter1.Fill(this.jewellerShopDataSet4.Products);

        }
		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Проверяем, является ли нажатая клавиша цифрой или клавишей Backspace
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true; // Отменяем ввод, если символ не является цифрой или Backspace
			}
		}

		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Проверяем, является ли нажатая клавиша цифрой или клавишей Backspace
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
			{
				e.Handled = true; // Отменяем ввод, если символ не является цифрой или Backspace
			}
		}

		private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
			{
				dataGridView1.ClearSelection();
				dataGridView1.Rows[e.RowIndex].Selected = true;

				ContextMenuStrip contextMenu = new ContextMenuStrip();
				ToolStripMenuItem editItem = new ToolStripMenuItem("Редактировать");
				ToolStripMenuItem deleteItem = new ToolStripMenuItem("Удалить");

				editItem.Click += EditItem_Click;
				deleteItem.Click += DeleteItem_Click;

				contextMenu.Items.Add(editItem);
				contextMenu.Items.Add(deleteItem);

				dataGridView1.ContextMenuStrip = contextMenu;
			}
		}
		private void EditItem_Click(object sender, EventArgs e)
		{
			// Логика редактирования элемента
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int selectedIndex = dataGridView1.SelectedRows[0].Index;

				int productId = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["Column1"].Value);

				// Редактирование элемента из базы данных
				using (var context = new JewellerContext())
				{
					var productToEdit = context.Products.FirstOrDefault(p => p.Id == productId);
					if (productToEdit != null)
					{
						ProductEditForm clientEditForm = new ProductEditForm(productToEdit);
						clientEditForm.ShowDialog();
					}
				}

				// Удаление строки из DataGridView
				dataGridView1.Rows.RemoveAt(selectedIndex);
			}
		}

		private void DeleteItem_Click(object sender, EventArgs e)
		{
			// Логика удаления элемента
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int selectedIndex = dataGridView1.SelectedRows[0].Index;

				int productId = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["Column1"].Value);

				// Удаление элемента из базы данных
				using (var context = new JewellerContext())
				{
					var productToDelete = context.Products.FirstOrDefault(p => p.Id == productId);
					if (productToDelete != null)
					{
						context.Products.Remove(productToDelete);
						context.SaveChanges();
					}
				}

				// Удаление строки из DataGridView
				dataGridView1.Rows.RemoveAt(selectedIndex);
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			using (var context = new JewellerContext())
			{

				if (!(textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && image == null))
				{
					int quantityInStock, price;
					int categoryId = 0;

					if (int.TryParse(textBox2.Text, out quantityInStock) &&
						int.TryParse(textBox3.Text, out price) &&
						comboBox1.SelectedItem != null)
					{
						var selectedCategory = (CategoryItem)comboBox1.SelectedItem;
						categoryId = selectedCategory.Id;

						Product newProduct = new Product
						{
							Image = ImageToByteArray(image),
							Name = textBox1.Text,
							QuantityInStock = quantityInStock,
							Price = price,
							Description = textBox4.Text,
							CategoryId = categoryId
						};

						context.Products.Add(newProduct);
						context.SaveChanges(); // Сохранить изменения в базе данных
						MessageBox.Show("Success");
					}
					else
					{
						MessageBox.Show("Invalid input for quantity, price, or category");
					}
				}
			}
			this.productsTableAdapter.Fill(this.jewellerShopDataSet.Products);
			dataGridView1.Refresh();
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

		private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.productsTableAdapter1.Fill(this.jewellerShopDataSet4.Products);
			dataGridView1.Refresh();
		}

		private void button2_Click(object sender, EventArgs e)
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
		}

		private void dataGridView1_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
			{
				dataGridView1.ClearSelection();
				dataGridView1.Rows[e.RowIndex].Selected = true;

				ContextMenuStrip contextMenu = new ContextMenuStrip();
				ToolStripMenuItem editItem = new ToolStripMenuItem("Редактировать");
				ToolStripMenuItem deleteItem = new ToolStripMenuItem("Удалить");

				editItem.Click += EditItem_Click;
				deleteItem.Click += DeleteItem_Click;

				contextMenu.Items.Add(editItem);
				contextMenu.Items.Add(deleteItem);

				dataGridView1.ContextMenuStrip = contextMenu;
			}
		}
	}
	public class CategoryItem
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
