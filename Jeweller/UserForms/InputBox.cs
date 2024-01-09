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
	public partial class InputBox : Form
	{
		public int SelectedNumber { get; private set; }
		public InputBox()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SelectedNumber = (int)numericUpDown1.Value;
			this.Close();
		}
	}
}
