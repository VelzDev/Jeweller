using System;
using System.Collections.Generic;
using System.ComponentModel;
using Jeweller.Context;
using Jeweller.Concrete;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jeweller.AdminForms;

namespace Jeweller
{
	public partial class ClientsViewForm : Form
	{
		public ClientsViewForm()
		{
			InitializeComponent();
		}

		private void ClientsViewForm_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "jewellerShopDataSet3.Users". При необходимости она может быть перемещена или удалена.
			this.usersTableAdapter1.Fill(this.jewellerShopDataSet3.Users);

        }

		private void button1_Click(object sender, EventArgs e)
		{
			var newUserForm = new RegisterForm();
			newUserForm.Show();
		}

		private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.usersTableAdapter1.Fill(this.jewellerShopDataSet3.Users);
			dataGridView1.Refresh();
			dataGridView1.Invalidate();
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

				int clientId = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["Column1"].Value);

				// Редактирование элемента из базы данных
				using (var context = new JewellerContext())
				{
					var clientToEdit = context.Users.FirstOrDefault(p => p.Id == clientId);
					if (clientToEdit != null)
					{
						ClientEditForm clientEditForm = new ClientEditForm(clientToEdit);
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

				int clientId = Convert.ToInt32(dataGridView1.Rows[selectedIndex].Cells["Column1"].Value);

				// Удаление элемента из базы данных
				using (var context = new JewellerContext())
				{
					var clientToDelete = context.Users.FirstOrDefault(p => p.Id == clientId);
					if (clientToDelete != null)
					{
						context.Users.Remove(clientToDelete);
						context.SaveChanges();
					}
				}

				// Удаление строки из DataGridView
				dataGridView1.Rows.RemoveAt(selectedIndex);
			}
		}
	}
}
