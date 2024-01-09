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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			InitRoot();
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

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void InitRoot()
		{
			using (var context = new JewellerContext())
			{
				string rootUsername = "root";
				var existingUser = context.Users.FirstOrDefault(u => u.Username == rootUsername);

				if (existingUser == null)
				{
					// Создать пользователя "root" и добавить его в базу данных
					User rootUser = new User
					{
						Address = "",
						PhoneNumber = "",
						Country = "",
						Username = rootUsername,
						Password = HashPassword(rootUsername),
						Email = "",
						admin = true
					};

					context.Users.Add(rootUser);
					context.SaveChanges(); // Сохранить изменения в базе данных
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string username = textBox1.Text;
			string password = textBox2.Text;

			using (var context = new JewellerContext()) // Создание экземпляра контекста базы данных
			{
				var user = context.Users.FirstOrDefault(u => u.Username == username);

				if (user != null)
				{
					// Здесь можно сравнить хеш пароля в базе данных с хешем введенного пароля
					string hashedPassword = HashPassword(password); // Хеширование введенного пароля

					if (hashedPassword == user.Password)
					{
						if (user.admin)
						{
							var adminForm = new AdminForm();
							adminForm.Show();
							this.Hide();
						}
						else
						{
							var userForm = new Catalog(user);
							userForm.Show();
							this.Hide();
						}
					}
					else
					{
						MessageBox.Show("Неверный пароль");
					}
				}
				else
				{
					MessageBox.Show("Пользователь не найден");
				}
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var RegForm = new RegisterForm();
			RegForm.ShowDialog();
		}
	}
}
