using Jeweller.Concrete;
using Jeweller.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeweller
{
	public partial class RegisterForm : Form
	{
		public RegisterForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!(textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == ""))
			{
				using (var context = new JewellerContext())
				{
					string Username = textBox4.Text;
					var existingUser = context.Users.FirstOrDefault(u => u.Username == Username);

					if (existingUser == null)
					{
						User newUser = new User
						{
							Address = textBox1.Text,
							PhoneNumber = textBox2.Text,
							Country = textBox3.Text,
							Username = Username,
							Password = HashPassword(textBox5.Text),
							Email = textBox6.Text,
							admin = false
						};

						context.Users.Add(newUser);
						context.SaveChanges(); // Сохранить изменения в базе данных
						MessageBox.Show("Success");
					}
				}
			}
			else MessageBox.Show("Error");
		}
		public string HashPassword(string password)
		{
			using (var sha256 = SHA256.Create())
			{
				byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

				// Преобразование хеша в строку
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < hashedBytes.Length; i++)
				{
					builder.Append(hashedBytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}
	}
}
