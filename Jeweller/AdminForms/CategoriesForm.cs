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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Jeweller.AdminForms
{
	public partial class CategoriesForm : Form
	{
		public CategoriesForm()
		{
			InitializeComponent();
		}

		private void CategoriesForm_Load(object sender, EventArgs e)
		{
            // TODO: данная строка кода позволяет загрузить данные в таблицу "jewellerShopDataSet2.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.jewellerShopDataSet2.Categories);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			using (var context = new JewellerContext())
			{

				if (!(textBox1.Text == ""))
				{
					Category newCategory = new Category
					{
						Name = textBox1.Text,
					};

					context.Categories.Add(newCategory);
					context.SaveChanges(); // Сохранить изменения в базе данных
					MessageBox.Show("Success");
				}
			}
			this.categoriesTableAdapter.Fill(this.jewellerShopDataSet2.Categories);
			dataGridView1.Refresh();
		}

		private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
			{
				dataGridView1.ClearSelection();
				dataGridView1.Rows[e.RowIndex].Selected = true;

				ContextMenuStrip contextMenu = new ContextMenuStrip();
				ToolStripMenuItem deleteItem = new ToolStripMenuItem("Удалить");

				deleteItem.Click += DeleteItem_Click;

				contextMenu.Items.Add(deleteItem);

				dataGridView1.ContextMenuStrip = contextMenu;
			}
		}

		private void DeleteItem_Click(object sender, EventArgs e)
		{
			// Логика удаления элемента
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int selectedIndex = dataGridView1.SelectedRows[0].Index;

				int catId = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["idDataGridViewTextBoxColumn"].Value);

				// Удаление элемента из базы данных
				using (var context = new JewellerContext())
				{
					var catToDelete = context.Categories.FirstOrDefault(p => p.Id == catId);
					if (catToDelete != null)
					{
						context.Categories.Remove(catToDelete);
						context.SaveChanges();
					}
				}

				// Удаление строки из DataGridView
				dataGridView1.Rows.RemoveAt(selectedIndex);
			}
		}
	}
}
