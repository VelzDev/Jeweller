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

namespace Jeweller.AdminForms
{
	public partial class ClientEditForm : Form
	{
		private User user;
		public ClientEditForm(User user)
		{
			InitializeComponent();
			textBox1.Text = user.Address;
			textBox2.Text = user.PhoneNumber;
			textBox3.Text = user.Country;
			textBox4.Text = user.Username;
			textBox5.Text = user.Email;
			this.user = user;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (var context = new JewellerContext())
			{
				User userToUpdate = context.Users.FirstOrDefault(u => u.Id == user.Id);
				if (userToUpdate != null)
				{
					userToUpdate.Address = textBox1.Text;
					userToUpdate.PhoneNumber = textBox2.Text;
					userToUpdate.Country = textBox3.Text;
					userToUpdate.Username = textBox4.Text;
					userToUpdate.Email = textBox5.Text;

					context.SaveChanges();
				}
			}
			this.Close();

		}
	}
}
