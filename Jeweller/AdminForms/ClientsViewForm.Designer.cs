namespace Jeweller
{
	partial class ClientsViewForm
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
			this.components = new System.ComponentModel.Container();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.adminDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.usersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.jewellerShopDataSet3 = new Jeweller.jewellerShopDataSet3();
			this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.jewellerShopDataSet1 = new Jeweller.jewellerShopDataSet1();
			this.jewellerShopDataSet = new Jeweller.jewellerShopDataSet();
			this.jewellerShopDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.usersTableAdapter = new Jeweller.jewellerShopDataSet1TableAdapters.UsersTableAdapter();
			this.button1 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.usersTableAdapter1 = new Jeweller.jewellerShopDataSet3TableAdapters.UsersTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.usersBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.jewellerShopDataSet3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.jewellerShopDataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.jewellerShopDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.jewellerShopDataSetBindingSource)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressDataGridViewTextBoxColumn,
            this.phoneNumberDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.adminDataGridViewCheckBoxColumn,
            this.Column1});
			this.dataGridView1.DataSource = this.usersBindingSource1;
			this.dataGridView1.Location = new System.Drawing.Point(0, 24);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(643, 226);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
			// 
			// addressDataGridViewTextBoxColumn
			// 
			this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
			this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
			this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
			this.addressDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// phoneNumberDataGridViewTextBoxColumn
			// 
			this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
			this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
			this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
			this.phoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// countryDataGridViewTextBoxColumn
			// 
			this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
			this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
			this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
			this.countryDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// usernameDataGridViewTextBoxColumn
			// 
			this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
			this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
			this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
			this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// emailDataGridViewTextBoxColumn
			// 
			this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
			this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
			this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
			this.emailDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// adminDataGridViewCheckBoxColumn
			// 
			this.adminDataGridViewCheckBoxColumn.DataPropertyName = "admin";
			this.adminDataGridViewCheckBoxColumn.HeaderText = "admin";
			this.adminDataGridViewCheckBoxColumn.Name = "adminDataGridViewCheckBoxColumn";
			this.adminDataGridViewCheckBoxColumn.ReadOnly = true;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "Id";
			this.Column1.HeaderText = "Column1";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// usersBindingSource1
			// 
			this.usersBindingSource1.DataMember = "Users";
			this.usersBindingSource1.DataSource = this.jewellerShopDataSet3;
			// 
			// jewellerShopDataSet3
			// 
			this.jewellerShopDataSet3.DataSetName = "jewellerShopDataSet3";
			this.jewellerShopDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// usersBindingSource
			// 
			this.usersBindingSource.DataMember = "Users";
			this.usersBindingSource.DataSource = this.jewellerShopDataSet1;
			// 
			// jewellerShopDataSet1
			// 
			this.jewellerShopDataSet1.DataSetName = "jewellerShopDataSet1";
			this.jewellerShopDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// jewellerShopDataSet
			// 
			this.jewellerShopDataSet.DataSetName = "jewellerShopDataSet";
			this.jewellerShopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// jewellerShopDataSetBindingSource
			// 
			this.jewellerShopDataSetBindingSource.DataSource = this.jewellerShopDataSet;
			this.jewellerShopDataSetBindingSource.Position = 0;
			// 
			// usersTableAdapter
			// 
			this.usersTableAdapter.ClearBeforeFill = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 256);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(618, 46);
			this.button1.TabIndex = 1;
			this.button1.Text = "Добавить пользователя";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(644, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// обновитьToolStripMenuItem
			// 
			this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
			this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
			this.обновитьToolStripMenuItem.Text = "Обновить";
			this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
			// 
			// usersTableAdapter1
			// 
			this.usersTableAdapter1.ClearBeforeFill = true;
			// 
			// ClientsViewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 305);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "ClientsViewForm";
			this.Text = "Клиенты";
			this.Load += new System.EventHandler(this.ClientsViewForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.usersBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.jewellerShopDataSet3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.jewellerShopDataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.jewellerShopDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.jewellerShopDataSetBindingSource)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource jewellerShopDataSetBindingSource;
		private jewellerShopDataSet jewellerShopDataSet;
		private jewellerShopDataSet1 jewellerShopDataSet1;
		private System.Windows.Forms.BindingSource usersBindingSource;
		private jewellerShopDataSet1TableAdapters.UsersTableAdapter usersTableAdapter;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
		private jewellerShopDataSet3 jewellerShopDataSet3;
		private System.Windows.Forms.BindingSource usersBindingSource1;
		private jewellerShopDataSet3TableAdapters.UsersTableAdapter usersTableAdapter1;
		private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn adminDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
	}
}