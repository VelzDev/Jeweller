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
	public partial class PaymentBox : Form
	{
		public PaymentBox()
		{
			InitializeComponent();
		}
		public string cardNumber { get; private set; }
		public string expDate { get; private set; }
		public string type { get; private set; }
		public string CVC { get; private set; }
		private void button1_Click(object sender, EventArgs e)
		{
			cardNumber = textBox1.Text;
			expDate = textBox2.Text;
			type = textBox4.Text;
			CVC = textBox3.Text;
			this.Close();
		}
	}
}
