namespace Hotel.RoomClassBedTypes
{
    partial class frmShowListBedTypesForRoomClass
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
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblClassName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRecordsCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvListBedTypesForRoomClass = new System.Windows.Forms.DataGridView();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddEditRoomClassBedTypes = new Guna.UI2.WinForms.Guna2Button();
            this.cmsListBedTypesForRoomClass = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBedTypesForRoomClass)).BeginInit();
            this.cmsListBedTypesForRoomClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(93, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(458, 52);
            this.lblTitle.TabIndex = 110;
            this.lblTitle.Text = "Bed Types For Room Class";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClassName
            // 
            this.lblClassName.BackColor = System.Drawing.Color.Transparent;
            this.lblClassName.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.ForeColor = System.Drawing.Color.DarkRed;
            this.lblClassName.Location = new System.Drawing.Point(241, 54);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(162, 42);
            this.lblClassName.TabIndex = 111;
            this.lblClassName.Text = "\' Standerd \'";
            this.lblClassName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Location = new System.Drawing.Point(104, 429);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(43, 23);
            this.lblRecordsCount.TabIndex = 117;
            this.lblRecordsCount.Text = "[????]";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 429);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(79, 23);
            this.guna2HtmlLabel1.TabIndex = 116;
            this.guna2HtmlLabel1.Text = "# Records :";
            // 
            // dgvListBedTypesForRoomClass
            // 
            this.dgvListBedTypesForRoomClass.AllowUserToAddRows = false;
            this.dgvListBedTypesForRoomClass.AllowUserToDeleteRows = false;
            this.dgvListBedTypesForRoomClass.AllowUserToOrderColumns = true;
            this.dgvListBedTypesForRoomClass.AllowUserToResizeColumns = false;
            this.dgvListBedTypesForRoomClass.AllowUserToResizeRows = false;
            this.dgvListBedTypesForRoomClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListBedTypesForRoomClass.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListBedTypesForRoomClass.BackgroundColor = System.Drawing.Color.White;
            this.dgvListBedTypesForRoomClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListBedTypesForRoomClass.ContextMenuStrip = this.cmsListBedTypesForRoomClass;
            this.dgvListBedTypesForRoomClass.Location = new System.Drawing.Point(1, 113);
            this.dgvListBedTypesForRoomClass.MultiSelect = false;
            this.dgvListBedTypesForRoomClass.Name = "dgvListBedTypesForRoomClass";
            this.dgvListBedTypesForRoomClass.ReadOnly = true;
            this.dgvListBedTypesForRoomClass.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvListBedTypesForRoomClass.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListBedTypesForRoomClass.Size = new System.Drawing.Size(646, 310);
            this.dgvListBedTypesForRoomClass.TabIndex = 115;
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.BorderRadius = 8;
            this.btnClose.BorderThickness = 1;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::Hotel.Properties.Resources.Close_32;
            this.btnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Location = new System.Drawing.Point(493, 429);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 45);
            this.btnClose.TabIndex = 108;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddEditRoomClassBedTypes
            // 
            this.btnAddEditRoomClassBedTypes.Animated = true;
            this.btnAddEditRoomClassBedTypes.BorderRadius = 8;
            this.btnAddEditRoomClassBedTypes.BorderThickness = 1;
            this.btnAddEditRoomClassBedTypes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddEditRoomClassBedTypes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddEditRoomClassBedTypes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddEditRoomClassBedTypes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddEditRoomClassBedTypes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddEditRoomClassBedTypes.FillColor = System.Drawing.SystemColors.Control;
            this.btnAddEditRoomClassBedTypes.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnAddEditRoomClassBedTypes.ForeColor = System.Drawing.Color.Black;
            this.btnAddEditRoomClassBedTypes.Image = global::Hotel.Properties.Resources.bed_add;
            this.btnAddEditRoomClassBedTypes.ImageSize = new System.Drawing.Size(50, 50);
            this.btnAddEditRoomClassBedTypes.Location = new System.Drawing.Point(578, 65);
            this.btnAddEditRoomClassBedTypes.Name = "btnAddEditRoomClassBedTypes";
            this.btnAddEditRoomClassBedTypes.Size = new System.Drawing.Size(69, 45);
            this.btnAddEditRoomClassBedTypes.TabIndex = 118;
            this.btnAddEditRoomClassBedTypes.Click += new System.EventHandler(this.btnAddEditRoomClassBedTypes_Click);
            // 
            // cmsListBedTypesForRoomClass
            // 
            this.cmsListBedTypesForRoomClass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsListBedTypesForRoomClass.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.cmsListBedTypesForRoomClass.Name = "cmsListBedTypesForRoomClass";
            this.cmsListBedTypesForRoomClass.Size = new System.Drawing.Size(141, 124);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::Hotel.Properties.Resources.bed_add_1_;
            this.addToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(140, 38);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Hotel.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(140, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(137, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Hotel.Properties.Resources.delete_column;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(140, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // frmShowListBedTypesForRoomClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 476);
            this.Controls.Add(this.btnAddEditRoomClassBedTypes);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.dgvListBedTypesForRoomClass);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowListBedTypesForRoomClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show List Bed Types For Room Class";
            this.Load += new System.EventHandler(this.frmShowListBedTypesForRoomClass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBedTypesForRoomClass)).EndInit();
            this.cmsListBedTypesForRoomClass.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblClassName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRecordsCount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.DataGridView dgvListBedTypesForRoomClass;
        private Guna.UI2.WinForms.Guna2Button btnAddEditRoomClassBedTypes;
        private System.Windows.Forms.ContextMenuStrip cmsListBedTypesForRoomClass;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}