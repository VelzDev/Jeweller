namespace Jeweller
{
	partial class Catalog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.корзинаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.избранноеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.корзинаToolStripMenuItem,
            this.избранноеToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 15;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// корзинаToolStripMenuItem
			// 
			this.корзинаToolStripMenuItem.Name = "корзинаToolStripMenuItem";
			this.корзинаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.корзинаToolStripMenuItem.Text = "Корзина";
			this.корзинаToolStripMenuItem.Click += new System.EventHandler(this.корзинаToolStripMenuItem_Click);
			// 
			// избранноеToolStripMenuItem
			// 
			this.избранноеToolStripMenuItem.Name = "избранноеToolStripMenuItem";
			this.избранноеToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
			this.избранноеToolStripMenuItem.Text = "Избранное";
			this.избранноеToolStripMenuItem.Click += new System.EventHandler(this.избранноеToolStripMenuItem_Click);
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Location = new System.Drawing.Point(783, 24);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(17, 434);
			this.vScrollBar1.TabIndex = 16;
			// 
			// Catalog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.vScrollBar1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Catalog";
			this.Text = "Каталог";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Catalog_FormClosed);
			this.Load += new System.EventHandler(this.Catalog_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem корзинаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem избранноеToolStripMenuItem;
		private System.Windows.Forms.VScrollBar vScrollBar1;
	}
}