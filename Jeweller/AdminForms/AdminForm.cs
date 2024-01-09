using Jeweller.AdminForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeweller
{
	public partial class AdminForm : Form
	{
		public AdminForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var newClientForm = new ClientsViewForm();
			newClientForm.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var productForm = new ProductViewForm();
			productForm.Show();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			var catForm = new CategoriesForm();
			catForm.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			var sellForm = new SalesViewForm();
			sellForm.Show();
		}

		private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
